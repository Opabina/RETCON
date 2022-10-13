#include <pch.h>
#include "Application.h"
#include "Logging/Logger.h"

namespace RETCON {
	Application::Application() { }
	Application::~Application() { }

	void Application::Run() {
		Logger app = Logger("Application");
		app.Log("App initialized.", LogType::Info);
		app.Log("Testing LogType Colors:\n", LogType::Info);

		app.Log("LogType::Success", LogType::Success);
		app.Log("LogType::Info", LogType::Info);
		app.Log("LogType::Warning", LogType::Warning);
		app.Log("LogType::Error", LogType::Error);
		app.Log("LogType::Critical", LogType::Critical);

		std::cin.get();
		return;
	}
}