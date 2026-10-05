using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PreBuild
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //jank time
            string relpath = Path.GetFullPath(AppContext.BaseDirectory + "..\\..\\..\\Configuration\\OSEPGlobals.cs");
            string g = File.ReadAllText(relpath);

            string sc64_matcher = @"SHELLCODE64 = new byte\[[0-9]{1,99}] {[a-fA-F0-9xX,\r\n ]{1,}};";
            string sc86_matcher = @"SHELLCODE86 = new byte\[[0-9]{1,99}] {[a-fA-F0-9xX,\r\n ]{1,}};";
            string sc64enc_matcher = @"SHELLCODE64_ENC = new byte\[[0-9]{1,99}] {[a-fA-F0-9xX,\r\n ]{1,}};";
            string sc86enc_matcher = @"SHELLCODE64_ENC = new byte\[[0-9]{1,99}] {[a-fA-F0-9xX,\r\n ]{1,}};";

            Match sc64 = Regex.Match(g, @"SHELLCODE64 = new byte\[[0-9]{1,99}] {[a-fA-F0-9xX,\r\n ]{1,}};");





            string t = sc64.ToString();

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

            bytes = Evasion.Encode(bytes);

            StringBuilder sb = new StringBuilder();
            sb.Append(sc64 + "\n\n");

            sb.Append($"SHELLCODE64_ENC = ");
            sb.Append($"new byte[{bytes.Length}] {{\n");

            sb.Append(BeautifyBytes(bytes, 20));

            sb.Append("};\n");

            //Remove old encoded versions
            g = Regex.Replace(g, sc64_matcher, sb.ToString());

            Console.WriteLine(g);

            


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
    }
}
