#pragma once
#include <string>
#include <iostream>
#include "Tile.h"
#include "Row.h"

using namespace std;

class Column : public Row
{
public :
	Column(); // constructor
	void Show() override;
};
