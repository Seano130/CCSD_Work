#pragma once
#include <iostream>
#include <string>
#include "Tile.h"
#include "Row.h"
#include "Column.h"
#include "Region.h"
#include <time.h>

using namespace std;

class Board
{
protected:
	Tile grid[9][9];
	Row rows[9];
	Column cols[9];
	Region rgns[9];
	int WhichRegion(int x, int y);
	int WhichTileWithinRegion(int x, int y);
	void ResetRow(int rowStart, int numRows);

public:
	Board();
	void Shuffle();
	bool IsConsistent();
	void Show();

};
