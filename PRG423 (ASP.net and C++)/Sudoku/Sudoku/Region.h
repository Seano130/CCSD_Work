#pragma once

#pragma once
#include <string>
#include <iostream>
#include "Tile.h"
#include "Row.h"

using namespace std;

class Region : public Row
{
public:
	Region(); // constructor
	void Show() override;
};

