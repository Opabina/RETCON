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

		void LogAssert(bool assert, std::string message = "");

	private:
		// Variables, "m_" prefix shows that these variables are private
		std::string m_Name;
		int m_LogCount = 0;
		bool m_OnSameLine = false;
	};

	class RETCON_API LoggerAssistant {
	public:
		static void Init();

		inline static std::shared_ptr<Logger>& GetCoreLogger() { return m_CoreLoggerPtr; }
		inline static std::shared_ptr<Logger>& GetApplicationLogger() { return m_AppLoggerPtr; }
	private:
		static std::shared_ptr<Logger> m_CoreLoggerPtr;
		static std::shared_ptr<Logger> m_AppLoggerPtr;
	};
}

// Core Logging Macros
#define RETCON_CORE_SUCCESS_LINE(msg)  ::RETCON::LoggerAssistant::GetCoreLogger()->LogLine(msg, RETCON::LogType::Success)
#define RETCON_CORE_SUCCESS(msg)       ::RETCON::LoggerAssistant::GetCoreLogger()->Log(msg, RETCON::LogType::Success)

#define RETCON_CORE_INFO_LINE(msg)     ::RETCON::LoggerAssistant::GetCoreLogger()->LogLine(msg, RETCON::LogType::Info)
#define RETCON_CORE_INFO(msg)          ::RETCON::LoggerAssistant::GetCoreLogger()->Log(msg, RETCON::LogType::Info)

#define RETCON_CORE_WARNING_LINE(msg)  ::RETCON::LoggerAssistant::GetCoreLogger()->LogLine(msg, RETCON::LogType::Warning)
#define RETCON_CORE_WARNING(msg)       ::RETCON::LoggerAssistant::GetCoreLogger()->Log(msg, RETCON::LogType::Warning)

#define RETCON_CORE_ERROR_LINE(msg)    ::RETCON::LoggerAssistant::GetCoreLogger()->LogLine(msg, RETCON::LogType::Error)
#define RETCON_CORE_ERROR(msg)         ::RETCON::LoggerAssistant::GetCoreLogger()->Log(msg, RETCON::LogType::Error)

#define RETCON_CORE_CRITICAL_LINE(msg) ::RETCON::LoggerAssistant::GetCoreLogger()->LogLine(msg, RETCON::LogType::Critical)
#define RETCON_CORE_CRITICAL(msg)      ::RETCON::LoggerAssistant::GetCoreLogger()->Log(msg, RETCON::LogType::Critical)

#define RETCON_CORE_ASSERT(...)     ::RETCON::LoggerAssistant::GetCoreLogger()->LogAssert(__VA_ARGS__)

// App Logging Macros
#define RETCON_SUCCESS_LINE(msg)       ::RETCON::LoggerAssistant::GetApplicationLogger()->LogLine(msg, RETCON::LogType::Success)
#define RETCON_SUCCESS(msg)            ::RETCON::LoggerAssistant::GetApplicationLogger()->Log(msg, RETCON::LogType::Success)
								       
#define RETCON_INFO_LINE(msg)          ::RETCON::LoggerAssistant::GetApplicationLogger()->LogLine(msg, RETCON::LogType::Info)
#define RETCON_INFO(msg)               ::RETCON::LoggerAssistant::GetApplicationLogger()->Log(msg, RETCON::LogType::Info)
								       
#define RETCON_WARNING_LINE(msg)       ::RETCON::LoggerAssistant::GetApplicationLogger()->LogLine(msg, RETCON::LogType::Warning)
#define RETCON_WARNING(msg)            ::RETCON::LoggerAssistant::GetApplicationLogger()->Log(msg, RETCON::LogType::Warning)
								       
#define RETCON_ERROR_LINE(msg)         ::RETCON::LoggerAssistant::GetApplicationLogger()->LogLine(msg, RETCON::LogType::Error)
#define RETCON_ERROR(msg)              ::RETCON::LoggerAssistant::GetApplicationLogger()->Log(msg, RETCON::LogType::Error)
								       
#define RETCON_CRITICAL_LINE(msg)      ::RETCON::LoggerAssistant::GetApplicationLogger()->LogLine(msg, RETCON::LogType::Critical)
#define RETCON_CRITICAL(msg)           ::RETCON::LoggerAssistant::GetApplicationLogger()->Log(msg, RETCON::LogType::Critical)
								       
#define RETCON_ASSERT(...)          ::RETCON::LoggerAssistant::GetApplicationLogger()->LogAssert(__VA_ARGS__)