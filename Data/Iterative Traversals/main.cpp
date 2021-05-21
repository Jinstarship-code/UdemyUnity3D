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
	Enqueue(root);

	while (!isQueueEmpty())
	{
		p = Dequeue(); //pop the item from queue and link it to lchild and rchild
		printf("Enter the left child of %d :  ", p->data);
		scanf("%d", &x);
		//Check for leaf node
		if (x != -1)
		{
			t = (struct Tree *)malloc(sizeof(struct Tree));
			t->data = x;
			t->lchild = t->rchild = NULL;
			p->lchild = t;
			Enqueue(t); //Insert the address of lchild in queue
		}
		printf("Enter the right child of %d : ", p->data);
		scanf("%d", &x);
		if (x != -1)
		{
			t = (struct Tree *)malloc(sizeof(struct Tree));
			t->data = x;
			t->lchild = t->rchild = NULL;
			p->rchild = t;
			Enqueue(t);
		}
	}
}

//Traversal using Recursion

void Preorder(struct Tree *p)
{
	if (p)
	{
		printf("%d ", p->data);
		Preorder(p->lchild);
		Preorder(p->rchild);
	}
}

void Inorder(struct Tree *p)
{
	if (p)
	{

		Inorder(p->lchild);
		printf("%d ", p->data);
		Inorder(p->rchild);
	}
}

void Postorder(struct Tree *p)
{
	if (p)
	{
		Postorder(p->lchild);
		Postorder(p->rchild);
		printf("%d ", p->data);
	}
}

//Traversal Using Iteration
void IPreorder(struct Tree *p)
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

void IInorder(struct Tree *p)
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

void IPostorder(struct Tree *p)
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

void LevelOrder(struct Node *root)
{
	struct Queue q;
	Create(&q, 100);

	printf("%d ", root->data);
	Enqueue(&q, root);

	while (!isQueueEmpty(q))
	{
		root = Dequeue(&q);

		if (root->lchild)
		{
			printf("%d ", root->lchild->data);
			Enqueue(&q, root->lchild);
		}

		if (root->rchild)
		{
			printf("%d ", root->rchild->data);
			Enqueue(&q, root->rchild);
		}
	}
}


int main()
{
	createTree();


	return 0;
}