#include <pch.h>
#include "Logger.h"
#include "TextUtils.h"

namespace RETCON {
	Logger::Logger(std::string name)
		: m_Name(name)
	{ }

	Logger::~Logger()
	{ }

	void Logger::Log(std::string message, LogType type) {
		CHANGE_TEXT_COL((int)type);
		std::cout << "[" << m_Name << "]: " << message << std::endl;

		m_LogCount++;
	}

	int Logger::GetLogCount() {
		return m_LogCount;
	}
}