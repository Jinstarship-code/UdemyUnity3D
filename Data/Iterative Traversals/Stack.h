//Stack.h

#include "Queue.h"
#ifndef Stack_h
#define Stack_h

struct Stack
{
	long int sdata; //Stack Data , Stores the address of each node. It's in long int format beacuse we need to store negative address.
	struct Stack *next;
} *top = NULL;

void push(long int x)
{
	struct Stack *t;
	t = (struct Stack *)malloc(sizeof(struct Stack));
	if (top == NULL)
	{
		t->sdata = x;
		t->next = NULL;
		top = t;
	}
	else
	{
		t->sdata = x;
		t->next = top;
		top = t;
	}
}
//Returns the address of a node of tree
long int pop()
{
	long int x;
	struct Stack *t;
	x = top->sdata;
	t = top->next;
	free(top);
	top = t;
	return x; //Returns the address of Node
}

int isStackEmpty()
{
	return top == NULL;
}

#endif