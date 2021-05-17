#pragma once
#include <iostream>

using namespace std;


class Node
{
public:
	Node *lchild;
	int data;
	Node *rchild;
};

class Queue
{
private:
	int front;
	int rear;
	int size;
	Node **Q;

public:
	Queue() { front = rear = -1; size = 10; Q = new Node*[size]; }
	Queue(int size) { front = rear = -1; this->size = size; Q = new Node*[this->size]; }

	void Enqueue(Node *x);
	Node* Dequeue();
	void Display();
};

void Queue::Enqueue(Node *x)
{
	if (rear == size - 1)
		cout << "Queue Full" << endl;
	else
	{
		rear++;
		Q[rear] = x;
	}
}

Node* Queue::Dequeue()
{
	Node* x = NULL;
	if (front == rear)
		cout << "Queue is Empty" << endl;
	else
	{
		x = Q[front + 1];
		front++;
	}
	return x;
}