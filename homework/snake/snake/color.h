/*
 * $Id: color.h,v 1.1.1.1 2003/09/01 01:59:39 casic Exp $
 *
 * color.h : define colors for LCD test
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

#ifndef _COLOR_H 
#define _COLOR_H

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
typedef unsigned short	COLOR;

/* color definition */
#define RED	0x000f
#define ORANGE	0x007f
#define YELLOW	0x00ff
#define GREEN	0x00f0
#define CYAN	0x0ff0
#define BLUE	0x0f00
#define PURPLE	0x0f07
#define WHITE	0x0fff
#define BLACK	0x0000
#define GRAY	0x0777

/* red */
#define red0	0x0000	/* scale 0 */
#define red1	0x0001	/* scale 1 */
#define red2	0x0002	/* scale 2 */
#define red3	0x0003	/* scale 3 */
#define red4	0x0004	/* scale 4 */
#define red5	0x0005	/* scale 5 */
#define red6	0x0006	/* scale 6 */
#define red7	0x0007	/* scale 7 */
#define red8	0x0008	/* scale 8 */
#define red9	0x0009	/* scale 9 */
#define reda	0x000a	/* scale a */
#define redb	0x000b	/* scale b */
#define redc	0x000c	/* scale c */
#define redd	0x000d	/* scale d */
#define rede	0x000e	/* scale e */
#define redf	0x000f	/* scale f */

/* green */
#define green0	0x0000	/* scale 0 */
#define green1	0x0010	/* scale 1 */
#define green2	0x0020	/* scale 2 */
#define green3	0x0030	/* scale 3 */
#define green4	0x0040	/* scale 4 */
#define green5	0x0050	/* scale 5 */
#define green6	0x0060	/* scale 6 */
#define green7	0x0070	/* scale 7 */
#define green8	0x0080	/* scale 8 */
#define green9	0x0090	/* scale 9 */
#define greena	0x00a0	/* scale a */
#define greenb	0x00b0	/* scale b */
#define greenc	0x00c0	/* scale c */
#define greend	0x00d0	/* scale d */
#define greene	0x00e0	/* scale e */
#define greenf	0x00f0	/* scale f */

/* blue */
#define blue0	0x0000	/* scale 0 */
#define blue1	0x0100	/* scale 1 */
#define blue2	0x0200	/* scale 2 */
#define blue3	0x0300	/* scale 3 */
#define blue4	0x0400	/* scale 4 */
#define blue5	0x0500	/* scale 5 */
#define blue6	0x0600	/* scale 6 */
#define blue7	0x0700	/* scale 7 */
#define blue8	0x0800	/* scale 8 */
#define blue9	0x0900	/* scale 9 */
#define bluea	0x0a00	/* scale a */
#define blueb	0x0b00	/* scale b */
#define bluec	0x0c00	/* scale c */
#define blued	0x0d00	/* scale d */
#define bluee	0x0e00	/* scale e */
#define bluef	0x0f00	/* scale f */

/* gray */
#define gray0	0x0000	/* scale 0 */
#define gray1	0x0111	/* scale 1 */
#define gray2	0x0222	/* scale 2 */
#define gray3	0x0333	/* scale 3 */
#define gray4	0x0444	/* scale 4 */
#define gray5	0x0555	/* scale 5 */
#define gray6	0x0666	/* scale 6 */
#define gray7	0x0777	/* scale 7 */
#define gray8	0x0888	/* scale 8 */
#define gray9	0x0999	/* scale 9 */
#define graya	0x0aaa	/* scale a */
#define grayb	0x0bbb	/* scale b */
#define grayc	0x0ccc	/* scale c */
#define grayd	0x0ddd	/* scale d */
#define graye	0x0eee	/* scale e */
#define grayf	0x0fff	/* scale f */

#endif /* _COLOR_H */
