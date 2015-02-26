/*
 * lcdexp.h : LCD driver
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

#ifndef _LCDEXP_H
#define _LCDEXP_H

#include "sys_ep7312.h"

/*
 * while write datas to LCD frame buffer, LCD will display them.
 * a pixel of the LCD is mapped to a bits block in the frame buffer
 * a pixel holds 12 bits in the frame buffer ( color LCD ):
 *  R - 4 bits ( 16-gray scale )
 *  G - 4 bits ( 16-gray scale )
 *  B - 4 bits ( 16-gray scale )
 */
/*
 * COLOR has 2 bytes :
 * COLOR[0-3]  : red
 * COLOR[4-7]  : green
 * COLOR[8-11] : blue
 * COLOR[12-15]: reserved
 */
typedef unsigned short  COLOR;

struct lcd_display {
	int             x1;	/* x axis */
	int             y1;	/* y axis */

	int             x2;	/* x axis */
	int             y2;	/* y axis */

	unsigned char	buf[32]; /* store character codes */

	COLOR	color;	/* display color */
};

/* ioctl cmd */
#define LCD_Clear		0

#define LCD_Pixel_Set		1
#define LCD_Big_Pixel_Set	2

#define LCD_Draw_VLine		3
#define LCD_Draw_HLine		4
#define LCD_Draw_VDashed	5
#define LCD_Draw_HDashed	6
#define LCD_Draw_Rectangle	7
#define LCD_Draw_Full_Rectangle	8

#define LCD_Write_EN		10
#define LCD_Write_CN		11

/* define device major */
#define DEV_MAJOR		60

#endif /* _LCDEXP_H */
