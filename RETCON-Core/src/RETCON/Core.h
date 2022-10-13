#pragma once

/*
* THE CORE FILE WILL INCLUDE DEFINITIONS SPECIAL TO THE CORE OF RETCON
* 
* I totally didn't steal this from TheCherno
*/

#if defined(_WIN32)
	#define RETCON_PLATFORM_WIN
	#if defined(RETCON_BUILD_DLL)
		#define RETCON_API __declspec(dllexport)
	#else
		#define RETCON_API __declspec(dllimport)
	#endif
#elif defined(__unix)
	#define RETCON_PLATFORM_UNIX
#elif defined(__unix)
#define RETCON_PLATFORM_LINUX
#elif defined(__APPLE__) && defined(__MACH__)
	#define RETCON_PLATFORM_MAC
#else
	#error UNKNOWN PLATFORM
#endif

#ifndef RETCON_PLATFORM_WIN
	#error UNSUPPORTED PLATFORM
#endif