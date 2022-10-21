#include <pch.h>
#include "GLFW/glfw3.h"

namespace RETCON {
	class RETCON_API Window {
	public:
		// Constructors / Destructors
		Window() = delete; // Delete default constructor cuz like we need arguments for our window
		Window(const std::string& name, const int& width, const int& height);
		~Window() {}

		// Event Functions
		void Update() {}
		void OnCreate() {}

		int GetWidth();
		int GetHeight();

	private:
		std::string m_WindowName;
		int m_WindowHeight;
		int m_WindowWidth;
	};
}