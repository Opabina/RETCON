#pragma once

//Pre-Definition
void ChangeConsoleColor(int col);

#if RETCON_PLATFORM_WIN
#include <windows.h>

void ChangeConsoleColor(int col) {
	HANDLE output = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(output, col);
}

#endif

#define CHANGE_TEXT_COL(col) ChangeConsoleColor(col)