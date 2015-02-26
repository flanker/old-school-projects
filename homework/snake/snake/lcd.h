/*
 * $Id: lcd.h,v 1.1.1.1 2003/09/01 01:59:39 casic Exp $
 *
 * lcd.h : LCD driver
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

#ifndef _LCD_H
#define _LCD_H

#include "color.h"

/* define data struct */
struct lcd_display {
	int             x1;      /* x axis */
	int             y1;      /* y axis */

	int             x2;      /* x axis */
	int             y2;      /* y axis */

	unsigned char   buf[32]; /* store character codes */

	COLOR    color;  /* display color */
};

/* define ioctl cmd */
#define LCD_Clear               0

#define LCD_Pixel_Set           1
#define LCD_Big_Pixel_Set       2

#define LCD_Draw_VLine          3
#define LCD_Draw_HLine          4
#define LCD_Draw_VDashed        5
#define LCD_Draw_HDashed        6
#define LCD_Draw_Rectangle      7
#define LCD_Draw_Full_Rectangle 8

#define LCD_Write_EN            10
#define LCD_Write_CN            11

void init_lcd(void);	/* initialize LCD */
void close_lcd(void);	/* close LCD */
void clear_lcd(void);	/* clear LCD */

/* 
 * draw a dot on the LCD
 * x,y : coordinates of the pixel to be displayed
 * color : the color of the dot
 */
void draw_dot(int x, int y, COLOR color);
void draw_big_dot(int x, int y, COLOR color); /* draw a big dot 2*2 */
void draw_vline(int x, int y1, int y2, COLOR color); /* draw a vertical line */
void draw_hline(int x1, int x2, int y, COLOR color); /* draw a horizontal line */
void draw_vdashed(int x, int y1, int y2, COLOR color); /* draw a vertical dashed */
void draw_hdashed(int x1, int x2, int y, COLOR color); /* draw a horizontal dashed */
/*
 * (start_x,start_y) : coordinate of the top-left-corner of the rectangle 
 * (end_x,end_y) : coordinate of the bottom-right-corner of the rectangle
 */
void draw_rectangle(int start_x, int start_y, int end_x, int end_y, COLOR color);
/*
 * (start_x,start_y) : coordinate of the top-left-corner of the rectangle 
 * (end_x,end_y) : coordinate of the bottom-right-corner of the rectangle
 * this rectangle is filled with pixels which color is the same as the frame
 */
void draw_full_rectangle(int start_x, int start_y, int end_x, int end_y, COLOR color);
void draw_circle(int x, int y, int r, COLOR color); /* (x,y) -- coordinate of the center of the circle */
/*
 * display an ascii character
 * x,y   : coordinates of the start pixel
 * codes : the the bytes serial to be displayed 
 * the size of the ascii characters is 8*16
 * color : the color of the character
 */
void write_en(int x, int y, unsigned char* codes, COLOR color);
/*                      
 * display a Chinese character
 * x,y   : coordinates of the start pixel
 * codes : the bytes serial to be displayed
 * the size of the Chinese characters is 16*16
 * color : the color of the character
 */
void write_cn(int x, int y, unsigned char* codes, COLOR color);
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
void write_str(int x, int y, char* str, COLOR color);

void draw_box(int x, int y, COLOR color);

#endif /* _LCD_H */
