#include <iostream>
#include <string>

using namespace std;

//passing by value
void Increase(int age)
{
	age++;
}

// passing by reference

void IncreaseByRef(int& age)
{
	++age;
}

// passing by reference also (by using a pointer)
void IncreaseByPtr(int* pAge)
{
	(*pAge)++;
}

int main()
{
	int age = 18;
	IncreaseByRef(age);
	cout << age << endl;

	system("pause");
	return 5;
}

