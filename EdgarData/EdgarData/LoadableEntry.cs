using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarData
{
    public interface LoadableEntry
    {
        void ReadHeading(StreamReader stream);
        bool ReadEntry(StreamReader stream);
    }
}
