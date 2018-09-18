#include <iostream> 
#include <string>
#include "Student.h"

using namespace std;



int main()
{
	Student s(18);
	s.Foo();
	s.Goo();
	int age = s.ShowAge();
	cout << "you are " << age << " years old." << endl;
	for (int i = 0; i < 900; i++)
	{
		s.BDay(); // have a birthday
	}
	cout << "now you are " << s.ShowAge() << " years old. " << endl;


	system("pause"); // pause program before exiting so user can see...
	return 5;
}

