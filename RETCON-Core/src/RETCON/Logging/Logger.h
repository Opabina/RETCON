#include <pch.h>

namespace RETCON {
	// Enum for Logging Types, hex numbers represent color code for console
	enum class LogType {
		Success = 0xA,
		Info = 0xF,
		Warning = 0xE,
		Error = 0xC,
		Critical = 0x4
	};

	// Main Logger Class
	class RETCON_API Logger {
	public:
		// Constructors / Deconstructors
		Logger(std::string name);
		~Logger();

		// Functions
		void LogLine(std::string message, LogType type);
		void Log(std::string message, LogType type);
		int GetLogCount();

		void LogAssert(bool assert);

	private:
		// Variables, "m_" prefix shows that these variables are private
		std::string m_Name;
		int m_LogCount = 0;
		bool m_OnSameLine = false;
	};
}