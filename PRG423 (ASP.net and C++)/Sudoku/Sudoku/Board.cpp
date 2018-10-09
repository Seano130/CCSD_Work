#include "Board.h"

Board::Board()
{
	// seed the random num generator
	// srand((unsigned int)time(NULL));
}

void Board::Shuffle()
{
	for (int y = 0; y < 9; y++)
	{
		for (int x = 0; y < 9; x++)
		{
			int rolls = 0; // count # of dice rolls
			bool cons = false;
			while (cons == false)
			{
				int r = (rand() % 9) + 1;
				Tile t(r); 
				rolls++; // increment rolls counter
				if (rolls > 30)
				{
					x = 0; // reset back to beginning of this row
					int numRows = 1;
					if (y > 4)
					{
						numRows = 3;
						y-= 2;
					}
					ResetRow(y, numRows); // clear out all Tiles in this row
					rolls = 0; // reset random roll counter
				}
				grid[x][y] = t; // place this new Tile into the grid
				rows[y].SetTile(x, t); // place reference to Tile in Row 
				cols[x].SetTile(y, t); // place reference to Tile in Col
				int rgn = WhichRegion(x, y); // 1st determine which region of 9
				int tileWithin = WhichTileWithinRegion(x, y); // 2nd find which element WITHIN that region
				rgns[rgn].SetTile(tileWithin, t);
				cons = true;
				for (int i = 0; i < 9; i++)
				{
					if( !rows[i].IsConsistent()) // re-check consistency for whole board
					{
						cons = false;
						break;
					}

					if (!cols[i].IsConsistent()) // re-check consistency for whole board
					{
						cons = false;
						break;
					}
					if (!rgns[i].IsConsistent())
					{
						cons = false;
						break;
					}
				}
			}
		}
	}
}

int Board::WhichRegion(int x, int y)
{
	if (x < 3)
	{
		if (y < 3)
		{
			return 0;
		}
		else if (y < 6)
		{
			return 3;
		}
		else
		{
			return 6;
		}
	}
	else if (x < 6)
	{
		if (y < 3)
		{
			return 1;
		}
		else if (y < 6)
		{
			return 4;
		}
		else
		{
			return 7;
		}
	}
	else
	{
		if (y < 3)
		{
			return 2;
		}
		else if (y < 6)
		{
			return 5;
		}
		else
		{
			return 8;
		}
	}
}

int Board::WhichTileWithinRegion(int x, int y)
{
	int rX = x % 3;
	int rY = y % 3;
	if (rX == 0)
	{
		if (rY == 0)
		{// upper left corner of region
			return 0;
		}
		else if (rY == 1)
		{// middle row, left col
			return 3;
		}
		else
		{// lower row, left col
			return 6;
		}
	}
	else if (rX == 1)
	{
		if (rY == 0)
		{// upper row, center col
			return 1;
		}
		else if (rY == 1)
		{// middle row, center col
			return 4;
		}
		else
		{// lower row, center col
			return 7;
		}
	}
	else
	{
		if (rY == 0)
		{// upper row, right col
			return 2;
		}
		else if (rY == 1)
		{// middle row, right col
			return 5;
		}
		else
		{// lower row, right col
			return 8;
		}
	}
}


bool Board::IsConsistent() 
{
	for (int i = 0; i < 9; i++)
	{
		if (!rgns[i].IsConsistent())
		{
			return false;

		}

		if (!rows[i].IsConsistent())
		{
			return false;
		}
		
		if (!cols[i].IsConsistent())
		{
			return false;
		}	
	}
	return true; // if we make it here, EVERYTHING is consistent
}

void Board::Show()
{
	for (int i = 0; i < 9; i++)
	{
		 rows[i].Show();
		// cols[i].Show(); Redundant tiles, not needed
		// rgns[i].Show(); Redundant tiles, not needed
	}
}


void Board::ResetRow(int rowStart, int numRows)
{
	for (int y = rowStart - numRows + 1; y < rowStart; y++)
	{
		for (int x = 0; x < 9; x++)
		{
			Tile t; // create a 0 Tile
			grid[x][y] = t; // place 0 in the grid
			rows[y].SetTile(x, t);
			cols[x].SetTile(y, t);
			int rgn = WhichRegion(x, y); // 1st determine which region of 9
			int tileWithin = WhichTileWithinRegion(x, y); // 2nd find which element WITHIN that region
			rgns[rgn].SetTile(tileWithin, t);

		}
	}
}
