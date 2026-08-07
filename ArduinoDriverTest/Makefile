PROG=test
SRCS=test.cpp mock.cpp
OBJS=$(SRCS:.cpp=.o)

CPP=g++

CPPFLAGS=-Dmock
LDFLAGS=-lm


World:$(PROG)

$(PROG): $(OBJS)
	$(CPP) -o $@ $^ $(LDFLAGS)

%.o: %.cpp
	$(CPP) -c -o $@ $^ $(CPPFLAGS)

clean:
	rm -f *.o $(PROG)
