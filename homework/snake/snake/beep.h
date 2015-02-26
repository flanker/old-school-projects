/*
 * beep.h : test beep driver
 *
 * Copyright (C) 2003 ynding (haoanian@263.net)
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

#ifndef _BEEP_H
#define _BEEP_H

/* file ioctl cmd */
#define BEEP_ON		0x01
#define BEEP_OFF	0x02

void beep_on();	/* turn on beep */
void beep_off();/* turn off beep */

#endif /* BEEP_H */
