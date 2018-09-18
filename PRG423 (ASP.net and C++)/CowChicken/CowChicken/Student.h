#pragma once
#include <string>


using namespace std;

class Student
{
public:
	Student(int age);
	string Goo();
	void Foo();
	int ShowAge();
	void BDay();
	int GetAge(); // getter
	void SetAge(int age); // setter
private:
	int age;
};
