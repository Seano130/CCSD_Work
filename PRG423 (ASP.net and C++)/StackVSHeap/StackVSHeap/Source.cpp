#include <iostream>
#include <string>
#include "Student.h"

using namespace std;

int main()
{
	// Stack Object...

	Student s1(18);
	s1.Bday();

	cout << "Stack object age: " << s1.Age << endl;

	//Heap Object
	Student* pS2 = new Student(30);
	pS2->Bday();

	cout << "Heap object age: " << pS2->Age << endl;
	
	delete pS2;

	system("pause");
	return 5;
}