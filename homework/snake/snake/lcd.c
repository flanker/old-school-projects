/*
 * lcd.c : Test LCD driver
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

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>


#include "lcd.h"




static int dev_fd;

void init_lcd(void)
{
	static o_flag = 0;

	if ( o_flag == 0 ) {
		dev_fd = open("/dev/lcd",O_WRONLY);
		++o_flag;
	}
	if(dev_fd<0)
	{	
         printf("cannot open /dev/lcd \n");
	} 
        else
	{
	printf("lcd open\n"); 
	}	
	
	return;
}

void close_lcd(void)
{
	static c_flag = 0;

	if ( c_flag == 0 ) {
		close(dev_fd);
		++c_flag;
	}
	
	return;
}

void clear_lcd(void)
{
	ioctl(dev_fd, LCD_Clear, 0);

	return;
}

/* 
 * draw a dot on the LCD
 * x,y : coordinates of the pixel to be displayed
 * color : the color of the dot
 */
void draw_dot(int x, int y, COLOR color)
{
	struct lcd_display	dot_display;

	dot_display.x1 = x;
	dot_display.y1 = y;
	dot_display.color = color;

	ioctl(dev_fd, LCD_Pixel_Set, &dot_display);

	return;
}

/* draw a big dot 2*2 */
void draw_big_dot(int x, int y, COLOR color)
{
	struct lcd_display	big_dot_display;

	big_dot_display.x1 = x;
	big_dot_display.y1 = y;
	big_dot_display.color = color;

	ioctl(dev_fd, LCD_Big_Pixel_Set, &big_dot_display);

	return;
}

/* draw a vertical line */
void draw_vline(int x, int y1, int y2, COLOR color)
{
	struct lcd_display      vline_display;

	vline_display.x1 = x;
	vline_display.y1 = y1;
	vline_display.y2 = y2;
	vline_display.color = color;

	ioctl(dev_fd, LCD_Draw_VLine, &vline_display);

	return;
}

/* draw a horizontal line */
void draw_hline(int x1, int x2, int y, COLOR color)
{
	struct lcd_display      hline_display;

	hline_display.x1 = x1;
	hline_display.x2 = x2;
	hline_display.y1 = y;
	hline_display.color = color;

	ioctl(dev_fd, LCD_Draw_HLine, &hline_display);
	
	return;
}

/* draw a vertical dashed */
void draw_vdashed(int x, int y1, int y2, COLOR color)
{
	struct lcd_display      vdashed_display;

	vdashed_display.x1 = x;
	vdashed_display.y1 = y1;
	vdashed_display.y2 = y2;
	vdashed_display.color = color;

	ioctl(dev_fd, LCD_Draw_VDashed, &vdashed_display);
								        
	return;
}

/* draw a horizontal dashed */
void draw_hdashed(int x1, int x2, int y, COLOR color)
{
	struct lcd_display      hdashed_display;

	hdashed_display.x1 = x1;
	hdashed_display.x2 = x2;
	hdashed_display.y1 = y;
	hdashed_display.color = color;

	ioctl(dev_fd, LCD_Draw_HDashed, &hdashed_display);

	return;
}

/*
 * (start_x,start_y) : coordinate of the top-left-corner of the rectangle 
 * (end_x,end_y) : coordinate of the bottom-right-corner of the rectangle
 */
void draw_rectangle(int start_x, int start_y, int end_x, int end_y, COLOR color)
{
	struct lcd_display      rect_display;

	rect_display.x1 = start_x;
	rect_display.y1 = start_y;
	rect_display.x2 = end_x;
	rect_display.y2 = end_y;
	rect_display.color = color;

	ioctl(dev_fd, LCD_Draw_Rectangle, &rect_display);

	return;
}

/*
 * (start_x,start_y) : coordinate of the top-left-corner of the rectangle 
 * (end_x,end_y) : coordinate of the bottom-right-corner of the rectangle
 * this rectangle is filled with pixels which color is the same as the frame
 */
void draw_full_rectangle(int start_x, int start_y, int end_x, int end_y, COLOR color)
{
	struct lcd_display      frect_display;

	frect_display.x1 = start_x;
	frect_display.y1 = start_y;
	frect_display.x2 = end_x;
	frect_display.y2 = end_y;
	frect_display.color = color;

	ioctl(dev_fd, LCD_Draw_Full_Rectangle, &frect_display);

	return;  
}

/* (x,y) -- coordinate of the center of the circle */
void draw_circle(int x, int y, int r, COLOR color)
{
	int x1 = 0;
	int y1 = r;
	int p = 3 - 2 * r;

	while(x1 <= y1 ) {

		draw_dot(x + x1,y + y1,color);
		draw_dot(x - x1,y + y1,color);
		draw_dot(x + x1,y - y1,color);
		draw_dot(x - x1,y - y1,color);
		draw_dot(x + y1,y + x1,color);
		draw_dot(x - y1,y + x1,color);
		draw_dot(x + y1,y - x1,color);
		draw_dot(x - y1,y - x1,color);
		if(p < 0)
			p+= 4 * x1++ +6;
		else
			p+= 4 * (x1++ - y1--) + 10;

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
void write_en(int x, int y, unsigned char* codes, COLOR color)
{
	int i = 0;

	struct lcd_display      en_display;

	en_display.x1 = x;
	en_display.y1 = y;
	en_display.color = color;

	for ( i=0;i<16;++i ) {
		en_display.buf[i] = codes[i];
	}

	ioctl(dev_fd, LCD_Write_EN, &en_display);

	return;  
}

/*
 * display a Chinese character
 * x,y   : coordinates of the start pixel
 * codes : the bytes serial to be displayed
 * the size of the Chinese characters is 16*16
 * color : the color of the character
 */
void write_cn(int x, int y, unsigned char* codes, COLOR color)
{
	int i = 0;

	struct lcd_display      cn_display;

	cn_display.x1 = x;
	cn_display.y1 = y;
	cn_display.color = color;

	for ( i=0;i<32;++i ) {
		cn_display.buf[i] = codes[i];
	}

	ioctl(dev_fd, LCD_Write_CN, &cn_display);

	return; 
}

/*
 * display a string, can contain both ascii characters and Chinese characters
 *
 * x,y : the beginning coordinates of the string to be displayed
 * 0<=x<=39 : each line holds 40 bytes (each byte contain 8 pixels) horizontally
 * 0<=y<=14 : each line holds 16 pixels vertically
 *
 * so the whole LCD can display 40*15 ascii characters,
 * or 20*15 Chinese characters
 *
 * color : the color of the string 
 */
void display_string(int x, int y, char* str, COLOR color)
{
	unsigned int    ch;
	unsigned int    cl;
	unsigned int    offset;

	unsigned char	buf[32];

	int zk_cn_fd;
	int zk_en_fd;

	zk_cn_fd = open("/mnt/nfs/apps/15.2_lcdtest/hzk16x16",O_RDONLY);
	zk_en_fd = open("/mnt/nfs/apps/15.2_lcdtest/ascii8x16",O_RDONLY);

	while (*str){
		ch = (unsigned int)str[0];
		cl = (unsigned int)str[1];

		if ( (ch>=0xa1)&&(ch<0xf8) && (cl>=0xa1)&&(cl<0xff) ) { /* Chinese characters */

			/* if x reaches the end of a line,turn to the next line */
			if ( x==39 || x==40 ){
				x = 0;
				y += 1;
			}

			/* calculate the offset of the character in the character storage */
			offset = ( (ch-0xa1)*94+(cl-0xa1) )*32;

			/* read the codes of the Chinese character */
			lseek(zk_cn_fd,offset,SEEK_SET);
			read(zk_cn_fd,buf,32);

			/* display the character */
			write_cn(x*8, y*16, buf, color);

			/* x axis increase 2 */
			x += 2;

			/* move to the next character */
			str += 2;       /* a Chinese character holds 2 bytes */

		}else{ /* ascii character */

			/* if x reaches the end of a line,turn to the next line */
			if ( x == 40 ) {
				x = 0;
				y += 1;
			}

			/* calculate the offset of the character in the character storage */
			offset = 16*ch;

			/* read the codes of the ascii character */
			lseek(zk_en_fd, offset, SEEK_SET);
			read(zk_en_fd, buf, 16);

			/* display the character */
			write_en(x*8, y*16, buf, color);

			/* x axis increase 1 */
			x += 1;

			/* move to the next character */
			str++;  /* an ascii character holds 1 byte */
		}

	}

	close(zk_en_fd);
	close(zk_cn_fd);

	return;
}

/* printf 4 colors' scales, and 7 characteristic colors */
void display_color_scales(void)
{
	static COLOR    red[] = {
		red0, red1, red2, red3, red4, red5, red6, red7,
		red8, red9, reda, redb, redc, redd, rede, redf
	};
	static COLOR    green[] = {
		green0, green1, green2, green3, green4, green5, green6, green7,
		green8, green9, greena, greenb, greenc, greend, greene, greenf
	};
	static COLOR    blue[] = {
		blue0, blue1, blue2, blue3, blue4, blue5, blue6, blue7,
		blue8, blue9, bluea, blueb, bluec, blued, bluee, bluef
	};
	static COLOR    gray[] = {
		gray0, gray1, gray2, gray3, gray4, gray5, gray6, gray7,
		gray8, gray9, graya, grayb, grayc, grayd, graye, grayf
	};

	int i = 0;

	for ( i=0;i<16;++i ) {
		/* red scale */
		draw_full_rectangle(20*i,0,20*(i+1),20,red[i]);

		/* green  scale */
		draw_full_rectangle(20*i,20,20*(i+1),40,green[i]);

		/* blue scale */
		draw_full_rectangle(20*i,40,20*(i+1),60,blue[i]);

		/* gray scale */
		draw_full_rectangle(20*i,60,20*(i+1),80,gray[i]);
	}

	/* characteristic  colors:red,orange,yellow,green,cyan,blue,purple */
	draw_full_rectangle(90,100,110,120,RED);
	draw_full_rectangle(110,100,130,120,ORANGE);
	draw_full_rectangle(130,100,150,120,YELLOW);
	draw_full_rectangle(150,100,170,120,GREEN);
	draw_full_rectangle(170,100,190,120,CYAN);
	draw_full_rectangle(190,100,210,120,BLUE);
	draw_full_rectangle(210,100,230,120,PURPLE);

	return;
}

void display_circles(void)
{
	draw_circle(50,120,20,RED);
	draw_circle(50,120,30,GREEN);
	draw_circle(270,120,20,BLUE);
	draw_circle(270,120,30,BLACK);

	return;
}

/* draw an interface, which looks like an oscillograph */
void draw_interface(void)
{
        int i = 0;
        static flag = 0;

        if ( flag == 0 ) {
                clear_lcd();
                ++flag;
        }

        //display_string(6, 0, "CASIC Waveform Display", GREEN);
        //display_string(0, 7, "0", GREEN);

        draw_rectangle(10, 20, 260, 220, GREEN);

        /* draw vertical dasheds */
        for ( i=0;i<9;++i ) {
                draw_vdashed(35+i*25, 20, 220, GREEN);
        }

        /* draw horizontal dasheds */
        for ( i=0;i<7;++i ) {
                draw_hdashed(10, 260, 45+i*25, GREEN);
        }

        /* draw vertical scales */
        /* left */
        draw_vdashed(11, 20, 220, GREEN);
        draw_vdashed(12, 20, 220, GREEN);

        /* middle */
        draw_vdashed(134, 20, 220, GREEN);
        draw_vdashed(135, 20, 220, GREEN);
        draw_vdashed(136, 20, 220, GREEN);

        /* right */
        draw_vdashed(258, 20, 220, GREEN);
        draw_vdashed(259, 20, 220, GREEN);

        /* draw horizontal scales */
        /* top */
        draw_hdashed(10, 260, 21, GREEN);
        draw_hdashed(10, 260, 22, GREEN);

        /* middle */
        draw_hdashed(10, 260, 119, GREEN);
        draw_hdashed(10, 260, 120, GREEN);
        draw_hdashed(10, 260, 121, GREEN);

        /* bottom */
        draw_hdashed(10, 260, 218, GREEN);
        draw_hdashed(10, 260, 219, GREEN);

        return;
}

/* convert datas to coordinates */
void data2pixel(unsigned char* buf, int count)
{
        unsigned char average = 0;

        unsigned char max = 0;
        unsigned char min = 0;

        int temp = 0;

        int i = 0;

        /* find out the max & min value */
        for ( i=0;i<count;++i ) {

                if ( min > buf[i])
                       min = buf[i];

                if ( max < buf[i])
                       max = buf[i];
        }

        /* calculate the middle value */
        average = max/2 + min/2;

        /* change data to coordinates */
        for ( i=0;i<count;++i ) {
                temp = (int)buf[i];
                temp -= (int)average;

                temp = temp*200/256;

                temp = 220 -100 - temp;

                buf[i] = (unsigned char)(temp & 0xff);
        }

        return;
}

/* erase the waveform pre-drawn */
void erase_wave(unsigned char* buf, int count)
{
        int i = 0;

        for ( i=0;i<count;++i ) {
                draw_big_dot(10+i*5, buf[i], GRAY);
        }
        return;
}

/* draw waveform */
void draw_wave(unsigned char* buf, int count)
{
        int i = 0;

        for ( i=0;i<count;++i ) {
                draw_big_dot(10+i*5, buf[i], YELLOW);
        }
        return;
}                                        


void draw_box(int x, int y, COLOR color)
{    
    draw_full_rectangle(x*10+1, y*10+1, (x+1)*10-1, (y+1)*10-1, color);    
}                               
