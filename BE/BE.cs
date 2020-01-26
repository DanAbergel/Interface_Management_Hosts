using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class BE
    {
        public enum theType
        {
           Hotel,
            Zimmer,
            Room
        }
        public enum Area {
            North,
            South,
            Center,
            Jerusalem
        }
        public enum Status { 
            NotYetAddressed,
            MailSent,
            Closed_Absence,
            Closed_Demanded
        }
        public enum StatutRequirement {
            Active,
            DealClosed,
            Closed
        }
        public enum Criterion {
            Necessary,
            Possible,
            NotInterested
        }
    }
}
