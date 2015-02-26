/*
 * $Id$
 *
 * beep.c : beep driver
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

#include "beep.h"

/* turn on the beep */
void beep_on(void)
{
	SYSCON2 |= BUZFREQ;
}

/* turn off the beep */
void beep_off(void)
{
	SYSCON2 &= ~BUZFREQ;
}

static int beep_open(struct inode *node, struct file *file)
{
	return 0;
}

static int beep_read(struct file *file, char *buff, size_t count, loff_t *offp)
{
	return 0;
}

static int beep_write(struct file *file, const char *buff, size_t count, loff_t *offp)
{
	return 0;
}

static int beep_ioctl(struct inode *inode, struct file *file, unsigned int cmd, unsigned long arg)
{
	switch ( cmd ) {

	case BEEP_ON:
	{
		beep_on();
		break;
	}
	case BEEP_OFF:
	{
		beep_off();
		break;
	}
	default:
		printk("unknown cmd\n");
		break;
	}

	return 0;
}

static int beep_release(struct inode *node, struct file *file)
{
	return 0;
}

static struct file_operations beep_fops = {
	owner:          THIS_MODULE,
	open:           beep_open,
	read:           beep_read,
	ioctl:		    beep_ioctl,
	write:          beep_write,
	release:        beep_release,
};

int beep_init(void)
{
	int result;

	result = register_chrdev(DEV_MAJOR,"beep",&beep_fops);
	if ( result < 0 ) {
		printk( KERN_INFO "beep:register beep failed !\n");

		return result;
	}

	printk("beep init\n");

	return 0;
}

static void __exit beep_exit(void)
{
	unregister_chrdev(DEV_MAJOR,"beep");

	return;
}

module_init(beep_init);
module_exit(beep_exit);

MODULE_LICENSE("GPL");
MODULE_AUTHOR("ynding");
MODULE_DESCRIPTION("ARM EP7312 beep driver");
MODULE_SUPPORTED_DEVICE("ARM");
