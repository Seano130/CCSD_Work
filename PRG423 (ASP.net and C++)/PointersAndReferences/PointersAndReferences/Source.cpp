#include <iostream>
#include <string>
#include "Student.h"

using namespace std;

int main()
{
	Student s1;
	s1.Age = 20;
	s1.Bday();

	cout << "s1 age = " << s1.Age << endl;

	Student* pS1 = &s1; // pointer to object s1
	pS1 -> Age = 25;
	pS1->Bday();

	cout << "s1 age is now = " << s1.Age << endl;
	cout << "pS1 address = " << pS1 << endl; // print out pointer address

	system("pause");
	return 5;
}