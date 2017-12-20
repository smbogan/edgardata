using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarData
{
    public class TagEntry : LoadableEntry
    {
        public string Tag { get; set; }
        public string Version { get; set; }
        public string Custom { get; set; }
        public string Abstract { get; set; }
        public string Datatype { get; set; }
        public string Iord { get; set; }
        public string Crdr { get; set; }
        public string Tlabel { get; set; }
        public string Doc { get; set; }

        public void ReadHeading(StreamReader stream)
        {
            stream.ReadLine();
        }

        public bool ReadEntry(StreamReader stream)
        {
            var line = stream.ReadLine();
            if (line == null)
                return false;

            var entries = line.Split('\t');

            int i = 0;

            Tag = entries[i++];
            Version = entries[i++];
            Custom = entries[i++];
            Abstract = entries[i++];
            Datatype = entries[i++];
            Iord = entries[i++];
            Crdr = entries[i++];
            Tlabel = entries[i++];
            Doc = entries[i++];

            return true;
        }
    }
}
