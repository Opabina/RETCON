#pragma once

// Pre-Definition
void ChangeConsoleColor(int col);

// Windows-specific code
#if RETCON_PLATFORM_WIN
#include <windows.h>

void ChangeConsoleColor(int col) {
	HANDLE output = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(output, col);
}

#endif

// Global Definition
#define CHANGE_TEXT_COL(col) ChangeConsoleColor(col)