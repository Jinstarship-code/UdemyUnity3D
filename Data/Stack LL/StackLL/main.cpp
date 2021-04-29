#include <stdio.h>
#include <stdlib.h>
#include <string>

struct Node
{
	int data;
	struct Node* next;
}*top=NULL;

void push(int x)
{
	struct Node *t;
	t = (struct Node*)malloc(sizeof(struct Node));

	//t가 생성이 안됨.
	if (t == NULL)
		printf("stack is full \n");
	else
	{
		t->data = x;
		t->next = top;
		top = t;
	}
}

char pop() 
{
	struct Node *t;
	char x = -1;
	if (top == NULL)
		printf("Stack is Empty\n");
	else
	{
		t = top;
		top = top->next;
		x = t->data;
		free(t);
	}
	return x;
}

void Display()
{
	struct Node *p;
	p = top;

	while (p != NULL)
	{
		printf("%d ", p->data);
		p = p->next;
	}
	printf("\n");
}

int isBalanced(const char *exp)
{
	for (int i = 0; exp[i] != '\0'; i++)
	{
		if (exp[i] == '('|| exp[i] == '{'|| exp[i] == '[')
			push(exp[i]);
		else if (exp[i] == ')'|| exp[i] == '}'|| exp[i] == ']')
		{
			if (top == NULL)
				return 0;
			pop();
		}
	}

	if (top == NULL)
		return 1;
	else
		return 0;
}


int main()
{
	const char *exp = "{([a+b]*[c-d])}";

	printf("%d ", isBalanced(exp));

	return 0;
}