#pragma once

namespace RETCON {
	class Application
	{
	public:
		Application();
		~Application();

		void Run();
	};

	Application* CreateApplication(); //Defined in Application
}
