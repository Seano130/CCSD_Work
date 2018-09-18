#include "Student.h"
#include <iostream>


Student::Student(int age)
{
	this->age = age;
}


void Student::Foo()
{
	cout << "Hello" << endl;
}

string Student::Goo()
{
	cout << "Bye" << endl;
	return "blah";

}

int Student::ShowAge()
{
	return age;
}

int Student::GetAge()
{
	if (age < 20)
	{ // if too young for bar, lie about it
		return 21;
	}
	else if (age < 25)
	{// if im old, lie abou it
		return age;
	}
	else
	{ // if im old, lie about it
		return 21;
	}
}

void Student::SetAge(int newAge)
{
	if (newAge < 29)
	{
		age = newAge;
	}
}

void Student::BDay()
{
	if (age < 29)
	{
		age++;
	}
}