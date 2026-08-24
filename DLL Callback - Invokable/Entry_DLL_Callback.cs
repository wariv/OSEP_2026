using System.Configuration;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OSEP
{
    [ComVisible(true)]
    public class OSEPRunner
    {
        private static readonly HttpClient Client = new HttpClient();

        public async Task OSEPExec()
        {
            await Client.GetAsync($"{CONFIG.HTTP_URL}/___hello_from_Csharp_DLL_Callback___.txt");
        }
    }
}