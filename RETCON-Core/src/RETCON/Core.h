#pragma once

/*
* THE CORE FILE WILL INCLUDE DEFINITIONS SPECIAL TO THE CORE OF RETCON
* 
* I totally didn't steal this from TheCherno
*/

// Platform Detection
#if defined(__linux__)
	#define RETCON_PLATFORM_LNX
#elif defined(_WIN32)
	#define RETCON_PLATFORM_WIN
#endif

// API Setup

// Linux
#if defined(RECTON_PLATFORM_LNX)
#if defined(RETCON_BUILD_DLL)
	#define RETCON_API __attribute__((dllexport))
#else
	#define RETCON_API __attribute__((dllimport))
#endif

// Windows
#elif defined(RETCON_PLATFORM_WIN)
	#if defined(RETCON_BUILD_DLL)
		#define RETCON_API __declspec(dllexport)
	#else
		#define RETCON_API __declspec(dllimport)
	#endif
#endif

#if !defined(RETCON_PLATFORM_WIN) && !defined(RETCON_PLATFORM_LNX)
	#error UNSUPPORTED PLATFORM
#endif

#define BIT(x) 1 << x