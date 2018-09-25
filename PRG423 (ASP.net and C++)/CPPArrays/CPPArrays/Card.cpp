#include "Card.h"
#include <iostream>


Card::Card()
{
	Index = 1;
	Face = "A";
	Value = 1;
}


Card::Card(int idx)
{
	Index = idx;
	if (Index == 1)
	{// Ace
		Face[0] = 'A';
		Value = 1;
	}
	else if (Index > 2 && Index <= 10)
	{ // Number cards
		Value = Index;
		char buffer[2];
	    _itoa_s(Index, buffer,2, 0);
		Face = buffer;
	}
	else if (Index == 11)
	{ // Jack
		Value = 10;
		Face[0] = 'J';
	}
	else if (Index == 12)
	{
		Value = 10;
		Face = "Q";
	}
	else if (Index == 13)
	{
		Value = 10;
		Face = "K";
	}
	else
	{
		cout << "Fire the programmer!" << endl;
	}
}