using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midi
{
    public enum MessageType
    {
        Channel,

        SystemExclusive,

        SystemCommon,

        SystemRealtime,

        Meta
    }
}
