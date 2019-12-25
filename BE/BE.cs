using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE
    {
        internal enum Type { Zimmer, Hotel, Camping }
        internal enum Area { North, South, Center, Jerusalem }
        internal enum Status { NotYetAddressed, MailSent, Closed_Absence, Closed_Demanded }
        internal enum StatutRequirement { Open, DealClosed, Closed }
        internal enum Criterion { Necessary, Possible, NotInterested }
    }
}
