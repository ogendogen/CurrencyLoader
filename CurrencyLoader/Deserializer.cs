using CurrencyLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencyLoader
{
    public static class Deserializer
    {
        public static FinalGAVOutput DeserializeFinalOutput(string json)
        {
            return JsonConvert.DeserializeObject<FinalGAVOutput>(json);
        }

        public static FinalGAVOutputWithRoot DeserializeFinalOutputWithRoot(string json)
        {
            return JsonConvert.DeserializeObject<FinalGAVOutputWithRoot>(json);
        }

        public static MediatedSchema DeserializeMediatedSchema(string json)
        {
            return JsonConvert.DeserializeObject<MediatedSchema>(json);
        }
    }
}
