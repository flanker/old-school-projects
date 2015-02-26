/*
 * beep.c : test beep driver
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

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>

#include "beep.h"

void beep_on()
{
	int dev_fd;

	dev_fd = open("/dev/beep",O_WRONLY);
	if ( dev_fd == -1 ) {
		printf("Cann't open file /dev/beep\n");
		exit(1);
	}


	ioctl(dev_fd, BEEP_ON, 0);

	close(dev_fd);

	return;
}

void beep_off(void)
{
	int dev_fd;

	dev_fd = open("/dev/beep",O_WRONLY);
	if ( dev_fd == -1 ) {
		printf("Cann't open file /dev/number \n");
		exit(1);
	}


	ioctl(dev_fd, BEEP_OFF, 0);

	close(dev_fd);

	return;
}
