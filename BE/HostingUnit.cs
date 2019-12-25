﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HostingUnit
    {
        public long HostingUnitKey { get; set; }
        static long HostingKey = 10000000;
        public Host Owner { get; set; }
        private string HostingUnitName { get; set; }
        bool[,] Diary { get; set; }

        //ctor
        public HostingUnit(long HostingUnitKey,Host Owner, string HostingUnitName)
        {
            this.HostingUnitKey = HostingUnitKey;
            this.Owner = Owner;
            this.HostingUnitName = HostingUnitName;
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
