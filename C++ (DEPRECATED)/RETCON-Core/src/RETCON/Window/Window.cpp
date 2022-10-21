#include <pch.h>
#include "Window.h"

namespace RETCON {
	Window::Window(const std::string& name, const int& width, const int& height)
		: m_WindowName(name), m_WindowWidth(width), m_WindowHeight(height)
	{
	}
}