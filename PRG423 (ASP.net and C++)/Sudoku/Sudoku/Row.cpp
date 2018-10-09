#include "Row.h"

Row::Row()
{
	tiles = new Tile[9](); // create the tiles array
}

void Row::SetTile(int idx, Tile& tile)
{
	tiles[idx] = tile; // place the incoming Tile into the array
}

bool Row::IsConsistent()
{
	for (int i = 0; i < 8; i++)
	{
		if (tiles[i].Value != 0)
		{ // only check non zero values because 0 indicates tile isn't set yet
			for (int j = 1 + 1; j < 9; j++)
			{
				if (tiles[j].Value != 0)
				{ // skip "0" tiles because they're not init'd yet
					if (tiles[i].Value == tiles[j].Value)
					{ // found a duplicate tile, so get out of function...
						return false;
					}
				}
			}
		}
	}
	// if we make it here, then no duplicates found, so return true
	return true;
}


void Row::Show()
{
	cout << "| "; // initial seperator
	for (int i = 0; i < 9; i++)
	{
		cout << tiles[i].Face << " | ";
	}
	cout << endl << endl;
}
