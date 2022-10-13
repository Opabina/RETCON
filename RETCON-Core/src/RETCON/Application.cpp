#include "pch.h"
#include "Application.h"

namespace RETCON {
	Application::Application() { }
	Application::~Application() { }

	void Application::Run() {
		std::cout << "App Running!" << std::endl;
	}
}