/*
 * lcdexp.c : LCD driver
 *
 * Copyright (C) 2003 ynding ( haoanian@263.net )
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 *
 */

#include <linux/kernel.h>
#include <linux/init.h>
#include <linux/module.h>
#include <linux/fs.h>
#include <linux/delay.h>
#include <asm/fcntl.h>
#include <asm/unistd.h>
#include <asm/io.h>
#include <asm/uaccess.h>





#include "lcdexp.h"

static unsigned char* __lcd_base;

/* Configuration of LCD */
static void setup_lcd(void)
{
	/* LCDEN[12] = 0 : Disable LCD before setting the registers of LCD */
	SYSCON1 &= ~0x00001000;
      
	/*
	 * set LCD Control Register
	 * Video Buffer Size[0:12] : 320*240*12 / 128 = 0x1c1f
	 * Line Length[13:18] : 320 / 16 -1 = 0x13
	 * Pixel Prescale[19:24] : 0x01
	 * AC Prescale[25:29] : 0x13
	 * GSEN[30] : =1,Enables gray scale output to LCD
	 * GSMD[31] : =1,4 bpp ( 16-gray scale )
	 */
	LCDCON = 0xe60f7c1f;

	/* Set Least/Most Significant Word - Set LCD Palette Register */
	PALLSW = 0x76543210;
	PALMSW = 0xfedcba98;

	/*
	 * Sets the start location in system memory for LCD frame buffer
	 * thus, the frame buffer starts from the location 0xc0000000
	 * in system memory
	 */
	
	FBADDR = 0xc;

	/* LCDEN[12] = 1 : Enable LCD after the LCD configuration */
	SYSCON1 |= 0x00001000;
	return;
}
/* 
 * draw a dot in the LCD
 * x,y : coordinate of the pixel to be lightened
 * color : the color of the dot
 */
static void lcd_pixel_set(int x, int y, COLOR color)
{
	unsigned char*	fb_ptr;
	COLOR pure_color = 0x0000;

	/* if the dot is out of the LCD, return */
	if ( x<0 || x>=320|| y<0 || y>=240) {
		return;
	}

	/* calculate the address according the dot */
	fb_ptr = __lcd_base + (x+y*320)*12/8;

	/* setup the image from the pixel to the frame buffer */
	if ( x & 0x1 ) {
		pure_color = ( color & 0x000f ) << 4;
		*fb_ptr &= 0x0f;
		*fb_ptr |= pure_color;
		
		pure_color = ( color & 0x0ff0 ) >> 4;
		*(fb_ptr+1) = 0xff & pure_color;

	} else {

		pure_color = color & 0x00ff;
		*fb_ptr = 0xff & pure_color;
		pure_color = ( color & 0x0f00 ) >> 8;
		*(fb_ptr+1) &= 0xf0;
		*(fb_ptr+1) |= pure_color;
	}

	return;
}

/*
 * clear all characters and graphics for LCD
 */
void clear_lcd(void)
{
        int x;
        int y;
        //struct lcd_pixel lcd_disp;

        for (y=0;y<240; y++) {
                for (x=0; x<320; x++) {
                        //lcd_disp.x = x;
                        //lcd_disp.y = y;
                        //lcd_disp.color = color;
                        lcd_pixel_set(x,y,0x0000);
                }
        }


        return;
}
/* draw a big dot 2*2 */
static void lcd_big_pixel_set(int x, int y, COLOR color)
{
	lcd_pixel_set( x, y, color);
	lcd_pixel_set( x, y+1, color);
	lcd_pixel_set( x+1, y, color);
	lcd_pixel_set( x+1, y+1, color);

	return;
}

/* draw a vertical line */
static void draw_vline(int x, int y1, int y2, COLOR color)
{
	int tmp; 
	int i = 0;
			        
	if ( y1>y2 ) {
		tmp = y1;
		y1 = y2;
		y2 = tmp;
	}

	tmp = y2 - y1;

	for ( i=0;i<=tmp;++i ) { 
		lcd_pixel_set(x,y1+i,color);
	}

	return;
}


/* draw a horizontal line */
static void draw_hline(int x1, int x2, int y, COLOR color)
{       
	int tmp;
	int i = 0;

	if ( x1>x2 ) {
		tmp = x1;
		x1 = x2;
		x2 = tmp;
	}

	tmp = x2 - x1;

	for ( i=0;i<=tmp;++i ) {
		lcd_pixel_set(x1+i,y,color);
	}

	return;
}

/* draw a vertical dashed */ 
static void draw_vdashed(int x, int y1, int y2, COLOR color)
{       
	int tmp;
	int i = 0;
			        
	if ( y1>y2 ) {
		tmp = y1;
		y1 = y2;
		y2 = tmp;
	}
				        
	tmp = y2 - y1;

	for ( i=0;i<=tmp;i+=5 ) {
		lcd_pixel_set(x, y1+i, color);
	}

	return;
}

/* draw a horizontal dashed */
static void draw_hdashed(int x1, int x2, int y, COLOR color)
{
	int tmp;
	int i = 0;

	if ( x1>x2 ) {
		tmp = x1;
		x1 = x2;
		x2 = tmp;
	}

	tmp = x2 - x1;

	for ( i=0;i<=tmp;i+=5 ) {
		lcd_pixel_set(x1+i, y, color);
	}

	return;
}

/*
 * (start_x,start_y) : coordinate of the top-left-corner of the rectangle 
 * (end_x,end_y) : coordinate of the bottom-right-corner of the rectangle
 */
static void draw_rectangle(int start_x,int start_y,int end_x,int end_y,COLOR color)
{
	draw_vline(start_x, start_y, end_y, color);
	draw_vline(end_x, start_y, end_y, color);
	draw_hline(start_x, end_x, start_y, color);
	draw_hline(start_x, end_x, end_y, color);

	return;
}


/*
 * (start_x,start_y) : coordinate of the top-left-corner of the rectangle 
 * (end_x,end_y) : coordinate of the bottom-right-corner of the rectangle
 * this rectangle is filled with pixels which color is the same as the frame
 */
static void draw_full_rectangle(int start_x, int start_y, int end_x, int end_y, COLOR color)
{
	int i = 0;
	int tmp = 0;

	tmp = end_x - start_x;

	for ( i=0;i<tmp;++i ) {
		draw_vline(start_x+i, start_y,end_y, color);
	}

	return;
}

/*
 * display an ascii character
 * x,y   : coordinates of the start pixel
 * codes : the the bytes serial to be displayed 
 * the size of the ascii characters is 8*16
 * color : the color of the character
 */
static void write_en(int x, int y, unsigned char* codes, COLOR color)
{
	int i = 0;

	/* total 16 bytes codes*/
	for ( i=0;i<16;++i ) {
		int j = 0;
		x += 8;

		for ( j=0;j<8;++j ) {
			--x;
			if ( (codes[i]>>j) & 0x1 ) {
				lcd_pixel_set(x, y, color);
			}
		}

		/* move to the next line : x axis unchanged, y axis increase 1 */
		++y;
	}

	return;
}

/*
 * display a Chinese character
 * x,y   : coordinates of the start pixel
 * codes : the bytes serial to be displayed
 * the size of the Chinese characters is 16*16
 * color : the color of the character
 */
static void write_cn(int x, int y, unsigned char* codes, COLOR color)
{
	int i;

	/* total 2*16 bytes codes */
	for(i=0;i<16;i++) {
		int j = 0;
		for (j=0;j<2;++j) {

			int k = 0;
			x += 8*(j+1);

			for ( k=0;k<8;++k ){
				--x;
				if ( ( codes[2*i+j] >> k) & 0x1 ) {
					lcd_pixel_set(x,y,color);
				}
			}
		}

		/* move to the next line : x axis unchanged, y axis increase 1 */
		x -= 8;
		++y;
	}

	return;
}

static int lcdexp_open(struct inode *node, struct file *file)
{
	return 0;
}

static int lcdexp_read(struct file *file, char *buff, size_t count, loff_t *offp)
{
	return 0;
}

static int lcdexp_write(struct file *file, const char *buff, size_t count, loff_t *offp)
{
	return 0;
}

static int lcdexp_ioctl(struct inode *inode, struct file *file, unsigned int cmd, unsigned long arg)
{
	switch ( cmd ) {
	case LCD_Clear:
	{
		clear_lcd();
		break;
	}
	case LCD_Pixel_Set:
	{
		struct lcd_display	pixel_display;

		if ( copy_from_user(&pixel_display,(struct lcd_display*)arg,sizeof(struct lcd_display))) {
			printk("copy_from_user error!\n");
			return -1;
		}

		lcd_pixel_set(pixel_display.x1, pixel_display.y1, pixel_display.color);

		break;
	}
	case LCD_Big_Pixel_Set:
	{
		struct lcd_display	b_pixel_display;

		if ( copy_from_user(&b_pixel_display,(struct lcd_display*)arg,sizeof(struct lcd_display))) {
			printk("copy_from_user error!\n");
			return -1;
		}

		lcd_big_pixel_set(b_pixel_display.x1, b_pixel_display.y1, b_pixel_display.color);

		break;
	}
	case LCD_Draw_VLine:
	{
		struct lcd_display	vline_display;

		if ( copy_from_user(&vline_display,(struct lcd_display*)arg,sizeof(struct lcd_display))) {
			printk("copy_from_user error!\n");
			return -1;
		}

		draw_vline(vline_display.x1, vline_display.y1, vline_display.y2, vline_display.color);

		break;
	}
	case LCD_Draw_HLine:
	{
		struct lcd_display      hline_display;

		if ( copy_from_user(&hline_display,(struct lcd_display*)arg,sizeof(struct lcd_display))) {
			printk("copy_from_user error!\n");
			return -1;
		}

		draw_hline(hline_display.x1, hline_display.x2, hline_display.y1, hline_display.color);
	}

	case LCD_Draw_VDashed:
	{
		struct lcd_display      vdashed_display;

		if ( copy_from_user(&vdashed_display,(struct lcd_display*)arg,sizeof(struct lcd_display))) {
			printk("copy_from_user error!\n");      
			return -1;                                                      
		}                                                                                       

		draw_vdashed(vdashed_display.x1, vdashed_display.y1, vdashed_display.y2,
			       	vdashed_display.color);

		break;
	}
	case LCD_Draw_HDashed:
	{       
		struct lcd_display      hdashed_display;

		if ( copy_from_user(&hdashed_display,(struct lcd_display*)arg,sizeof(struct lcd_display))) {
			printk("copy_from_user error!\n");
			return -1;
		} 

		draw_hdashed(hdashed_display.x1, hdashed_display.x2, hdashed_display.y1,
			       	hdashed_display.color);

		break;                                                                  
	}       
	case LCD_Draw_Rectangle:
	{
		struct lcd_display      rect_display;

		if ( copy_from_user(&rect_display,(struct lcd_display*)arg,sizeof(struct lcd_display))) {
			printk("copy_from_user error!\n");
			return -1;
		}

		draw_rectangle(rect_display.x1, rect_display.y1,
			       	rect_display.x2, rect_display.y2, rect_display.color);

		break;
	}         
	case LCD_Draw_Full_Rectangle:
	{
		struct lcd_display      frect_display;

		if ( copy_from_user(&frect_display,(struct lcd_display*)arg,sizeof(struct lcd_display))) {
			printk("copy_from_user error!\n");
			return -1;
		}

		draw_full_rectangle(frect_display.x1, frect_display.y1,
			       	frect_display.x2, frect_display.y2, frect_display.color);

		break;                                                          
	}                        
	case LCD_Write_EN:
	{
		struct lcd_display      en_display;

		if ( copy_from_user(&en_display,(struct lcd_display*)arg,sizeof(struct lcd_display))) {
			printk("copy_from_user error!\n");
			return -1;
		}

		write_en(en_display.x1, en_display.y1, en_display.buf, en_display.color);

		break;                                                          
	}                        
	case LCD_Write_CN:
	{
		struct lcd_display      cn_display;

		if ( copy_from_user(&cn_display,(struct lcd_display*)arg,sizeof(struct lcd_display))) {
			printk("copy_from_user error!\n");
			return -1;
		}

		write_cn(cn_display.x1, cn_display.y1, cn_display.buf, cn_display.color);

		break;        
	}
	default:
		printk("unknown cmd\n");
		break;
	}

	return 0;
}

static int lcdexp_release(struct inode *node, struct file *file)
{
        
 	__lcd_base = (unsigned char *)0xc0000000;

	return 0;
}

static struct file_operations lcdexp_fops = {
	//owner:          THIS_MODULE,
        open:           lcdexp_open,
	read:           lcdexp_read,
	ioctl:		lcdexp_ioctl,
	write:          lcdexp_write,
	release:        lcdexp_release,
};

int lcdexp_init(void)
{
	int result;
        int i;

	__lcd_base = (unsigned char*)0xc0000000;
	result = register_chrdev(DEV_MAJOR,"lcdexp",&lcdexp_fops);
	if ( result < 0 ) {
		printk( KERN_INFO "lcdexp:register lcdexp failed !\n");

		return result;
	}
 	setup_lcd();
        for ( i=0;i<320*240*12/8;i++ )
	{
          *__lcd_base++ = 0x77;
	}
        __lcd_base =(unsigned char*)0xc0000000;
        printk("LCD------------support.\n");

	return 0;
}

static void __exit lcdexp_exit(void)
{
	/* clear LCD */
	unregister_chrdev(DEV_MAJOR,"lcdexp");

	return;
}

module_init(lcdexp_init);
module_exit(lcdexp_exit);

