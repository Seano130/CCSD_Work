#include <iostream>
#include <string>
#include "Card.h"

using namespace std;

int main()
{
	Card deck[13];
	for (int i = 1; i <= 13; i++)
	{
		Card c(i);
		deck[i - 1] = c;
	}

	for (int i = 0; i <= 13; i++)
	{
		deck[i].Show();
	}

	system("pause");
	return 7;
}