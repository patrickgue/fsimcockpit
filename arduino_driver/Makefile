PROG=test
SRCS=test.c mock.c
OBJS=$(SRCS:.c=.o)

CFLAGS=-Dmock

World:$(PROG)

$(PROG): $(OBJS)
	$(CC) -o $@ $^ $(LDFLAGS)

%.o: %.c
	$(CC) -c -o $@ $^ $(CFLAGS)

clean:
	rm -f *.o $(PROG)
