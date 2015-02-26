CC = /usr/local/arm/2.95.3/bin/arm-linux-gcc 
DEBFLAGS = -O2
CFLAGS = -D__KERNEL__ -I/source/linux-2.4.13-casic/include -Wall -Wstrict-prototypes -Wno-trigraphs -O2 -fno-strict-aliasing -fno-common -DMODULE
OBJS = LCD.o
all: $(OBJS)
clean:
	rm -f $(OBJS)
