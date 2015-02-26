CC = /usr/local/arm/2.95.3/bin/arm-linux-gcc

all: snake  

snake: keyboard.c lcd.c main.c beep.c
#	$(CC) -s -Wl,-warn-common --static -o $@ $^
	$(CC) -s -Wl,-warn-common -o $@ $^
    
clean :
	-rm -f snake
