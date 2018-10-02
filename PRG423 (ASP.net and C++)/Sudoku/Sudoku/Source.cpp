#include <iostream>
#include <string>
#include <time.h>
#include <math.h>
#include "Tile.h"

using namespace std;

bool HasDupes(Tile tiles[9])
{
	for (int i = 0; i < 8; i++)
	{
		for (int j = i + 1; j < 9; j++)
		{
			if (tiles[i].Value == tiles[j].Value 
				&& tiles[i].Value != 0 // 0 is not a dupe
				&& tiles[j].Value != 0) // 0 is not a dupe
			{
				return true;
			}
		}
	}
}

int main()
{

	srand((unsigned int)time(NULL));
	Tile tiles[9];
	for (int i = 0; i < 9; i++)
	{
		int r = 0;
		do
		{

			r = (rand() % 9) + 1; // range is 1 -> 9
			Tile t(r); // create a new tile using the random number
			tiles[i] = t; // put this Tile into the array
		} 
		while (HasDupes(tiles) == true || i < 8);
	}

	cout << "| ";

	for (int i = 0; i < 9; i++)
	{
		cout << tiles[i].Face << " | ";
	}
	cout << endl; // finish the row

	system("pause");
}