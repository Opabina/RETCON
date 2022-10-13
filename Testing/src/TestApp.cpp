#include "RETCON.h"

class Test : public RETCON::Application
{};

RETCON::Application* RETCON::CreateApplication() {
	return new Test();
}