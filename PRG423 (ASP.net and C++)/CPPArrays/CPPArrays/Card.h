#pragma once
#include <string>

using namespace std;

class Card
{
public:
	int Index;
	int Value;
	string Face;
	Card(); // default constructor
	Card(int idx); // parameter constructor
	void Show();
};