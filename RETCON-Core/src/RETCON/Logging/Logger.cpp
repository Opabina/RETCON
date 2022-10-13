#include <pch.h>
#include "Logger.h"
#include "TextUtils.h"

namespace RETCON {
	// Constructors / Deconstructors
	Logger::Logger(std::string name)
		: m_Name(name)
	{ }

	Logger::~Logger()
	{ }

	// Functions
	void Logger::Log(std::string message, LogType type) {
		// Macro to change Text Color of Console (see TextUtils.h for code)
		CHANGE_TEXT_COL((int)type);

		// Log Message to console
		if(m_OnSameLine)
			std::cout << message;
		else
			std::cout << "[" << m_Name << "]: " << message;

		// Increase log count
		m_LogCount++;
		m_OnSameLine = true;
	}

	void Logger::LogLine(std::string message, LogType type) {
		// Macro to change Text Color of Console (see TextUtils.h for code)
		CHANGE_TEXT_COL((int)type);

		// Log Message to console
		if (m_OnSameLine)
			std::cout << message << std::endl;
		else
			std::cout << "[" << m_Name << "]: " << message << std::endl;
		// Increase log count
		m_LogCount++;
		m_OnSameLine = false;
	}

	int Logger::GetLogCount() {
		return m_LogCount;
	}

	void Logger::LogAssert(bool assert) {
		if (assert) {
			LogLine("Assertion success!", LogType::Success);
			return;
		}

		LogLine("Assertion failed!", LogType::Error);
	}
}