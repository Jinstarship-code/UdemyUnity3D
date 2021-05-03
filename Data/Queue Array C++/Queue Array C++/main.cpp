#include <iostream>

using namespace std;

class Queue
{
private:
	int front;
	int rear;
	int size;
	int *Q;

public:
	Queue() { front = rear = -1; size = 10; Q = new int[size]; }
	Queue(int size) { front = rear = -1; this->size = size; Q = new int[this->size]; }
	
	void Enqueue(int x);
	int Dequeue();
	void Display();
};

void Queue::Enqueue(int x)
{
	if (rear == size - 1)
		cout << "Queue Full"<<endl;
	else
	{
		rear++;
		Q[rear] = x;
	}
}

int Queue::Dequeue()
{
	int x = -1;
	if (front == rear)
		cout << "Queue is Empty" << endl;
	else
	{
		x = Q[front + 1];
		front++;
	}
	return x;
}

void Queue::Display()
{
	for (int i = front + 1; i <= rear; i++)
		cout << Q[i]<<' ';
	cout << endl;
}

int main()
{
	Queue q(5);

	q.Enqueue(10);
	q.Enqueue(20);
	q.Enqueue(30);

	q.Display();
	q.Dequeue();
	q.Display();
	return 0;
}