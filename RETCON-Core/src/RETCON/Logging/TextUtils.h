#pragma once

// Pre-Definition
void ChangeConsoleColor(int col);

// Windows-specific code
#if defined(RETCON_PLATFORM_WIN)
#include <windows.h>

void ChangeConsoleColor(int col) {
	HANDLE output = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(output, col);
}

#elif defined(RETCON_PLATFORM_LNX)
/*
* Checkout https://dev.to/tenry/terminal-colors-in-c-c-3dgc for info on how terminal colors in Linux work
* Checkout https://man7.org/linux/man-pages/man5/terminal-colors.d.5.html for a list of linux terminal colors
*/

#include <iostream>

void ChangeConsoleColor(int col) {
	std::cout << "\033[" << col << "m";
}

#endif

// Global Definition
#define CHANGE_TEXT_COL(col) ChangeConsoleColor(col)