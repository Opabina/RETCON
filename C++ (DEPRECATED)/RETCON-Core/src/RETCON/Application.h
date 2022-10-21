#pragma once

#include <pch.h>

namespace RETCON {
	class RETCON_API Application
	{
	public:
		Application();
		virtual ~Application();

		void Run();
	};

	Application* CreateApplication(); //Defined in external C++ Application (see Testing Project for example)
}
