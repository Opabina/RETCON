#pragma once

/*
* ENTRY POINT FOR RETCON
* USED FOR C++ APPS USING RETCON CORE
*/

#include "Logging/Logger.h"

#if defined(RETCON_PLATFORM_WIN)
	extern RETCON::Application* RETCON::CreateApplication();
	
	int main(int argc, char** argv) {
		// Initialize Loggers
		RETCON::LoggerAssistant::Init();
		RETCON_CORE_SUCCESS_LINE("Logger Initialized!");
		RETCON_INFO_LINE("Creating Application...");

		// Create App
		auto app = RETCON::CreateApplication();
		RETCON_SUCCESS("Application Created! ");
		RETCON_INFO_LINE("Running...");

		app->Run();
		delete app;
	}
#endif