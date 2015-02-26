/*
 * $Id
 *
 * sys_ep7312.h : define system registers
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

#ifndef _SYS_EP7312_H
#define _SYS_EP7312_H

#define	SYSCON1		*(unsigned long*)0xff000100	/* System control register 1 */
#define	SYSCON2		*(unsigned long*)0xff001100	/* System control register 2 */

#define PADR		*(unsigned char*)0xff000000     /* PORT A data register */
#define PADDR		*(unsigned char*)0xff000040     /* PORT A data direction register */

#define PBDR		*(unsigned char*)0xff000001     /* PORT B data register */
#define PBDDR		*(unsigned char*)0xff000041     /* PORT B data direction register */

#define MEMCFG1		*(unsigned long*)0xff000180

#define LCDCON		*(unsigned long*)0xff0002c0 /* LCD Control Register */
#define PALLSW		*(unsigned long*)0xff000540 /* Least Significant 32-bit Word of Palette Register */
#define PALMSW		*(unsigned long*)0xff000580 /* Most  Significant 32-bit Word of Palette Register */
#define FBADDR		*(unsigned long*)0xff001000 /* LCD Frame Buffer Start Address */

#define BUZFREQ		(0x1<<14)

#endif /* _SYS_EP7312_H */
