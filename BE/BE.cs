﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE
    {
        internal enum theType { Zimmer, Hotel, Camping }
        internal enum Area { North, South, Center, Jerusalem }
        internal enum Status { NotYetAddressed, MailSent, Closed_Absence, Closed_Demanded }
        internal enum StatutRequirement { Active, DealClosed, Closed }
        internal enum Criterion { Necessary, Possible, NotInterested }
    }
}
