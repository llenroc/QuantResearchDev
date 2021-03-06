﻿using Microsoft.WindowsAzure.Storage.Table;
using Moon.Config;
using Moon.Data.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Moon.Resources.Management;

namespace Moon.Global
{
    public static class Shared
    {
        public static ConfigGlobal Config = new ConfigGlobal();
        public static Perf Manager = new Perf();
        public static NodeUri ConfigUri = new NodeUri();
        public static bool StoreInLocalAzureDB = true;
        public static Core IncomingBinance = new Core();
        public static bool Running = true;
        public static CloudTable table = null;
        public static int MaxLiveListTick = 20;
    }
}
