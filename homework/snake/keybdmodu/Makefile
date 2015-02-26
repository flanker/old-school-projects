CC = /usr/local/arm/2.95.3/bin/arm-linux-gcc
INCLUDEDIR = /usr/include
KERNELDIR = /usr/include/linux/kernel.h
##include $(KERNELDIR)/config.h
CFLAGS = -D__KERNEL__ -I/source/linux-2.4.13-casic/include -Wall -Wstrict-prototypes -Wno-trigraphs -O2 -fno-strict-aliasing -fno-common -fno-common -DMODULE
OBJS = keybd.o
all: $(OBJS)
clean: 
	rm -f $(OBJS)

