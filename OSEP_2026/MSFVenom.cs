using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSEP_2026
{
    public class MSFVenomPayload
    {
        public string Name { get; set; }
        public MSFVenomArch Architecture { get; set; }
        public bool staged { get; set; }
    }

    public enum MSFVenomArch
    {
        x64,
        x86
    }

    public partial class MSFVenom
    {
        
        public List<MSFVenomPayload> payloads = new List<MSFVenomPayload>();


        //Class constructor
        public MSFVenom()
        {
            PopulatePayloads();
        }

        



    }


}
