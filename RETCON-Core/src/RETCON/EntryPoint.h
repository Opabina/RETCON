#pragma once

/*
* ENTRY POINT FOR RETCON
* USED FOR C++ APPS USING RETCON CORE
*/

#if defined(RETCON_PLATFORM_WIN)
	extern RETCON::Application* RETCON::CreateApplication();
	
	int main(int argc, char** argv) {
		auto app = RETCON::CreateApplication();
		app->Run();
		delete app;
	}
#endif