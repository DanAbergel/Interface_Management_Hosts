﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLFactory
    {
        public static IBL GetBL()
        {
            return new BL_imp();
        }
    }
}
