#include "Region.h"

Region::Region()
{
	tiles = new Tile[9]();
}

void Region::Show()
{
	cout << endl;
	/*
	for (int i = 0; i < 3; i++)
	{
		cout << "| " << tiles[i].Face << " | ";
	}
	cout << endl;
	for (int i = 0; i < 6; i++)
	{
		cout << "| " << tiles[i].Face << " | ";
	}
	cout << endl;
	for (int i = 0; i < 9; i++)
	{
		cout << "| " << tiles[i].Face << " | ";
	}*/


	//another way to display tiles
	for (int i = 0; i < 9; i++)
	{
		cout << "| " << tiles[i].Face << " | ";
		if ((i + 1) % 3 == 0)
		{
			cout << endl;
		}
	}


	cout << endl;
}