#include "QueueCpp.h"

class Tree
{
public:
	Node *root;

	Tree() { root = NULL; }

	void CreateTree();
	void Preorder(Node *p);
	void Postorder(Node *p);
	void Inorder(Node *p);
	void Levelorder(Node *p);
	void Height(Node *root);
};

int main()
{

	return 0;
}

void Tree::CreateTree()
{
	Node *p, *t;
	int x;
	Queue q(100);
	
	cout << "Enter root value : ";
	cin >> x;
	root = new Node;
	root->data = x;
	root->lchild = root->rchild = NULL;
	P->lchild = t;
}

void Tree::Preorder(Node * p)
{
}

void Tree::Postorder(Node * p)
{
}

void Tree::Inorder(Node * p)
{
}

void Tree::Levelorder(Node * p)
{
}

void Tree::Height(Node * root)
{
}
