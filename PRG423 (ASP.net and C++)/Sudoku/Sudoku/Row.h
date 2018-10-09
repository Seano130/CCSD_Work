#pragma once

#include <string>
#include "Tile.h"
#include <iostream>

using namespace std;

class Row
{
protected:
	Tile* tiles;

public:
	Row();
	void SetTile(int idx, Tile& tile);
	bool IsConsistent();
	virtual void Show(); // virtual to prepare for override later
};