#pragma once

/*
* ENTRY POINT FOR RETCON
* USED FOR C++ APPS USING RETCON CORE
*/

#include "Logging/Logger.h"
#include "Window/Window.h"

#if defined(RETCON_PLATFORM_WIN)
	extern RETCON::Application* RETCON::CreateApplication();
	
	int main(int argc, char** argv) {
		// Initialize Loggers
		RETCON::LoggerAssistant::Init();

		RETCON_CORE_SUCCESS_LINE("Core Logger Initialized!");
		RETCON_SUCCESS_LINE("Application Logger Initialized!");

		RETCON::Window window("Title Pending", 640, 200);

		// Create App
		auto app = RETCON::CreateApplication();
		app->Run();
		delete app;
	}
#elif defined(RETCON_PLATFORM_LNX)
	extern RETCON::Application* RETCON::CreateApplication();

	int main() {
		// Initialize Loggers
		RETCON::LoggerAssistant::Init();

		RETCON_CORE_SUCCESS_LINE("Core Logger Initialized!");
		RETCON_SUCCESS_LINE("Application Logger Initialized!");

		// Create App
		auto app = RETCON::CreateApplication();
		app->Run();
		delete app;
	}
#endif