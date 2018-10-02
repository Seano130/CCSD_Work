#include "Tile.h"

Tile::Tile(int val)
{
	Value = val; // store the incoming suggested value for this tile
	char* pBuf = new char[10]();
	_itoa_s(val, pBuf, 10, 10);
	Face = *pBuf;
}


Tile::Tile()
{ // default constructor for an unknown tile
	Value = 0;
	Face = "0";
}