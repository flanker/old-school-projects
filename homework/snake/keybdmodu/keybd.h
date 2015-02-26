/*
 * $Id: keybd.h,v 1.2 2003/08/29 03:13:18 casic Exp $
 *
 * keybd.h : keyboard driver
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

#ifndef _KEYBD_H
#define _KEYBD_H

#include "sys_ep7312.h"

/* the keyboard has total 4x4 keys */
#define COL	4
#define ROW	4

/* define ioctl cmd */
#define NONBLOCK	0x01
#define BLOCK		0x02

/* define device major */

#define DEV_MAJOR	59

#endif  /* _KEYBD_H */
