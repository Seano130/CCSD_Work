#include <iostream>
#include <string>
#include <time.h>
#include "Board.h"

using namespace std;



int main()
{

	srand((unsigned int)time(NULL));

	Board b;
	b.Shuffle();
	b.Show();
	

	system("pause");
}