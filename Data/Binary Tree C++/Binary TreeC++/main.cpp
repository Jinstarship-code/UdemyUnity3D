#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include "QueueCpp.h"

class Tree
{
private:
	Node *root;

public:

	Tree() { root = NULL; }

	void CreateTree();
	void Preorder() { Preorder(root); }
	void Preorder(Node *p);
	void Postorder() { Postorder(root); }
	void Postorder(Node *p);
	void Inorder() { Inorder(root); }
	void Inorder(Node *p);
	void Levelorder() { Levelorder(root); }
	void Levelorder(Node *p);
	int Height() { return Height(root); }
	int Height(Node *root);
};


void Tree::CreateTree()
{
	Node *p, *t;
	int x;
	Queue q(100);
	
	std::cout << "Enter root value : ";
	std::cin >> x;
	root = new Node;
	root->data = x;
	root->lchild = root->rchild = NULL;

	q.Enqueue(root);

	while (!q.isEmpty())
	{
		p = q.Dequeue();
		printf("Enter left child of %d ", p->data);
		scanf("%d", &x);
		if (x != -1)
		{
			t = new Node;
			t->data = x;
			t->lchild = t->rchild = NULL;
			p->lchild = t;
			q.Enqueue(t);
		}
		printf("Enter right child of %d ", p->data);
		scanf("%d", &x);
		if (x != -1)
		{
			t = new Node;
			t->data = x;
			t->lchild = t->rchild = NULL;
			p->rchild = t;
			q.Enqueue(t);
		}
	}
}

void Tree::Preorder(Node * p)
{
	if (p)
	{
		printf("%d ", p->data);
		Preorder(p->lchild);
		Preorder(p->rchild);
	}
}

void Tree::Postorder(Node * p)
{
	if (p)
	{
		Postorder(p->lchild);
		Postorder(p->rchild);
		printf("%d ", p->data);
	}
}

void Tree::Inorder(Node * p)
{
	if (p)
	{
		Inorder(p->lchild);
		printf("%d ", p->data);
		Inorder(p->rchild);
	}
}

void Tree::Levelorder(Node * p)
{
	Queue q(100);

	printf("%d ", root->data);
	q.Enqueue(root);

	while (!q.isEmpty())
	{
		root = q.Dequeue();
		if (root->lchild)
		{
			printf("%d ", root->lchild->data);
			q.Enqueue(root->lchild);
		}
		if (root->rchild)
		{
			printf("%d ", root->rchild->data);
			q.Enqueue(root->rchild);
		}
	}
}

int Tree::Height(Node * root)
{
	int x = 0, y = 0;
	if (root == 0)
		return 0;

	x = Height(root->lchild);
	y = Height(root->rchild);

	if (x > y)
		return x + 1;
	else
		return y + 1;

}

int main()
{
	Tree t;
	t.CreateTree();
	std::cout << "Preorder ";
	t.Preorder();
	std::cout << "\nInorder ";
	t.Inorder();
	std::cout << "\nPostorder ";
	t.Postorder();
	return 0;
}
