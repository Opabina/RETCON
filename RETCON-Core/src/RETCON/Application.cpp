#include <pch.h>
#include "Application.h"
#include "Logging/Logger.h"

namespace RETCON {
	Application::Application() { }
	Application::~Application() { }

	void Application::Run() {
		Logger app = Logger("Application");
		app.LogLine("App initialized.", LogType::Info);
		app.LogLine("Testing LogType Colors:\n", LogType::Info);

		app.LogLine("LogType::Success", LogType::Success);
		app.LogLine("LogType::Info", LogType::Info);
		app.LogLine("LogType::Warning", LogType::Warning);
		app.LogLine("LogType::Error", LogType::Error);
		app.LogLine("LogType::Critical\n", LogType::Critical);

		app.LogLine("Testing Assertions\n", LogType::Info);
		app.Log("1 == 1: ", LogType::Info);
		app.LogAssert(1 == 1);

		app.Log("1 == 5: ", LogType::Info);
		app.LogAssert(1 == 5);

		std::cin.get();
		return;
	}
}