/*
 * $Id: keybd.c,v 1.2 2003/08/29 03:13:18 casic Exp $
 *
 * keybd.c : keyboard driver
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

#include "keybd.h"


/* define the meaning of each key on the keyboard */
static char key[ROW][COL] = {
	{'1','2','3','a'},
	{'4','5','6','b'},
	{'7','8','9','c'},
	{'*','0','#','d'}
};

/* initialize keyboard */
void init_keybd(void)
{
	PADDR |= 0x00;

	SYSCON2 |= 0x00000008;
	SYSCON1 |= 0x00000008;

	return;
}

/* 
 * keyboard scan, capture key pressed
 * block : block or non-block
 */
char keyscan(unsigned int block)
{
	unsigned long pa_value;	/* store the value read from the PA port */
	unsigned long column = 0x000000008; /* write the value of column to SYSCON1,
					       the initial value 0x8 will cause the 
					       voltage of col0 to high */
	char keyvalue = 'x';	/* while keyvalue == 'x', means that no key is pressed */

	int col = 0;

	/* will loop until there is a key pressed */
	do {
		/* initial the variables before each loop of keyboard scan */
		keyvalue = 'x';
		column = 0x00000008;

		/* this for loop execute a single loop for keyboard scanning,
		   from col0 to col3:
		   firstly, set col0 to high, others to low ,
		   then, set col1 to high, others to low, and so on */
		for ( col=0;col<4;++col ) {
			int row = 0;

			SYSCON1 &= ~0x0000000f;
			SYSCON1 |= column;
	
			mdelay(2);
	
			PADDR |= 0x00;	/* set PA port as input */
			pa_value = PADR;/* read data from PA port */
			pa_value &= 0xf;/* take out the value useful to us */

			if ( pa_value != 0 ) {	/* means there is a key pressed */
				/* this for loop determines which key is pressed */ 
				for ( row=0;row<4;++row ) {
					if ( (pa_value >> row) & 0x1 ) {
						keyvalue = key[row][col];
						break;
					}
				}
			}

			if ( keyvalue != 'x' )
				break;

			++column;
		}

	} while ( keyvalue=='x' && block );

	mdelay(100);
	
	return keyvalue;
}

static int keybd_open(struct inode *node, struct file *file)
{
	return 0;
}

static int keybd_read(struct file *file, char *buff, size_t count, loff_t *offp)
{
	return 0;
}

static int keybd_write(struct file *file, const char *buff, size_t count, loff_t *offp)
{
	return 0;
}

static int keybd_ioctl(struct inode *inode, struct file *file, unsigned int cmd, unsigned long arg)
{
	char key = 'x';

	switch ( cmd ) {

	case NONBLOCK:
	{
		key = keyscan(0x0);
		break;
	}
	case BLOCK:
	{
		key = keyscan(0x1);
		break;
	}
	default:
		printk("unknown cmd\n");
		break;
	}

	if ( copy_to_user((char*)arg, &key, sizeof(char))) {
		printk("copy_to_user error!\n");
		return -1;
	}

	return 0;
}

static int keybd_release(struct inode *node, struct file *file)
{
	return 0;
}

static struct file_operations keybd_fops = {
	owner:          THIS_MODULE,
	open:           keybd_open,
	read:           keybd_read,
	ioctl:		keybd_ioctl,
	write:          keybd_write,
	release:        keybd_release,
};

int keybd_init(void)
{
	int result;

	result = register_chrdev(DEV_MAJOR,"keybd",&keybd_fops);
	if ( result < 0 ) {
		printk( KERN_INFO "keybd:register keybd failed !\n");

		return result;
	}

	printk("keybd init\n");

	return 0;
}

static void __exit keybd_exit(void)
{
	unregister_chrdev(DEV_MAJOR,"keybd");

	return;
}

module_init(keybd_init);
module_exit(keybd_exit);

MODULE_LICENSE("GPL");
MODULE_AUTHOR("ynding");
MODULE_DESCRIPTION("ARM EP7312 keyboard driver");
MODULE_SUPPORTED_DEVICE("ARM");
