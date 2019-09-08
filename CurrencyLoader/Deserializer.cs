﻿using CurrencyLoader.Models;
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
    }
}