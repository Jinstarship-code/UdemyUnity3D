//Tree.c
#define _CRT_SECURE_NO_WARNINGS
#include "Queue.h"
#include "Stack.h"

void createTree()
{
	struct Tree *p, *t;
	int x;
	printf("Enter The Value of Root : ");
	scanf("%d", &x);
	root = (struct Tree *)malloc(sizeof(struct Tree));
	root->data = x;
	root->lchild = root->rchild = NULL;
	enQueue(root);
	while (!isQueueEmpty())
	{
		p = deQueue(); //pop the item from queue and link it to lchild and rchild
		printf("Enter the left child of %d :  ", p->data);
		scanf("%d", &x);
		//Check for leaf node
		if (x != -1)
		{
			t = (struct Tree *)malloc(sizeof(struct Tree));
			t->data = x;
			t->lchild = t->rchild = NULL;
			p->lchild = t;
			enQueue(t); //Insert the address of lchild in queue
		}
		printf("Enter the right child of %d : ", p->data);
		scanf("%d", &x);
		if (x != -1)
		{
			t = (struct Tree *)malloc(sizeof(struct Tree));
			t->data = x;
			t->lchild = t->rchild = NULL;
			p->rchild = t;
			enQueue(t);
		}
	}
}

//Traversal using Recursion

void preOrder(struct Tree *p)
{
	if (p)
	{
		printf("%d ", p->data);
		preOrder(p->lchild);
		preOrder(p->rchild);
	}
}

void inOrder(struct Tree *p)
{
	if (p)
	{

		inOrder(p->lchild);
		printf("%d ", p->data);
		inOrder(p->rchild);
	}
}

void postOrder(struct Tree *p)
{
	if (p)
	{
		postOrder(p->lchild);
		postOrder(p->rchild);
		printf("%d ", p->data);
	}
}

//Traversal Using Iteration
void IPreOrder(struct Tree *p)
{
	long int temp;

	while (p || !isStackEmpty())
	{
		if (p)
		{
			printf("%d ", p->data);
			push((long int)p);
			p = p->lchild;
		}
		else
		{
			temp = pop();
			p = (struct Tree *)temp;
			p = p->rchild;
		}
	}
}

void IInOrder(struct Tree *p)
{
	long int temp;
	while (p || !isStackEmpty())
	{
		if (p)
		{

			push((long int)p);
			p = p->lchild;
		}
		else
		{
			temp = pop();
			p = (struct Tree *)temp;
			printf("%d ", p->data);
			p = p->rchild;
		}
	}
}

void IPostOrder(struct Tree *p)
{
	long int temp;
	while (p || !isStackEmpty())
	{
		if (p)
		{
			push((long int)p);
			p = p->lchild;
		}
		else
		{
			temp = pop();
			if (temp > 0)
			{
				push(-temp);
				p = (struct Tree *)temp;
				p = p->rchild;
			}
			else
			{
				p = (struct Tree *) - temp;
				printf("%d ", p->data);
				p = NULL;
			}
		}
	}
}

int main()
{
	createTree();
	printf("\nPreorder Traversal is : ");
	IPreOrder(root);
	printf("\n");
	printf("\nInorder Traversal is : ");
	IInOrder(root);
	printf("\n");
	printf("\nPostorder Traversal is : ");
	IPostOrder(root);
	printf("\n");
	return 0;
}