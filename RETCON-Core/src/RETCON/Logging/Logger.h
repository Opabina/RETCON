#include <pch.h>

namespace RETCON {
	enum class LogType {
		Success = 0xA,
		Info = 0xF,
		Warning = 0xE,
		Error = 0xC,
		Critical = 0x4
	};

	class RETCON_API Logger {
	public:
		Logger(std::string name);
		~Logger();

		void Log(std::string message, LogType type);
		int GetLogCount();

	private:
		std::string m_Name;
		int m_LogCount = 0;
	};
}