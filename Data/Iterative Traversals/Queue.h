#include <stdio.h>
#include <stdlib.h>

#ifndef Queue_h
#define Queue_h
// Tree Structure
struct Tree
{
	struct Tree *lchild;
	int data;
	struct Tree *rchild;
} *root = NULL;

//Queue Structure
struct Queue
{
	struct Tree *qdata; //Store the address of Tree
	struct Queue *next;
} *front = NULL, *rear = NULL;

void Enqueue(struct Tree *x)
{
	struct Queue *t;
	t = (struct Queue *)malloc(sizeof(struct Queue));
	if (t == NULL)
	{
		printf("Queue is Full!");
	}
	else
	{
		t->qdata = x;
		t->next = NULL;
		if (front == NULL)
		{
			front = rear = t; //When the queue doesn't exist
		}
		else
		{
			rear->next = t; //Insert from rear
			rear = t;
		}
	}
}



struct Tree *Dequeue()
{
	struct Tree *x = NULL;
	struct Queue *t;
	if (front == NULL)
	{
		printf("Queue is Empty!");
	}
	else
	{
		t = front;
		x = t->qdata;
		front = t->next;
		free(t);
	}
	return x;
}

int isQueueEmpty()
{
	return front == NULL;
}
#endif