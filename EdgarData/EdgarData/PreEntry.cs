using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarData
{
    public class PreEntry : LoadableEntry
    {
        public string Adsh { get; set; }
        public string Report { get; set; }
        public string Line { get; set; }
        public string Stmt { get; set; }
        public string Inpth { get; set; }
        public string Rfile { get; set; }
        public string Tag { get; set; }
        public string Version { get; set; }
        public string Plabel { get; set; }

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

            Adsh = entries[i++];
            Report = entries[i++];
            Line = entries[i++];
            Stmt = entries[i++];
            Inpth = entries[i++];
            Rfile = entries[i++];
            Tag = entries[i++];
            Version = entries[i++];
            Plabel = entries[i++];

            return true;
        }
    }
}
