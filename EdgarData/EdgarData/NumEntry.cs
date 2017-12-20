using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarData
{
    public class NumEntry : LoadableEntry
    {
        public string Adsh { get; set; }
        public string Tag { get; set; }
        public string Version { get; set; }
        public string Coreg { get; set; }
        public YYYYMMDD Ddate { get; set; }
        public int Qtrs { get; set; }
        public string Uom { get; set; }
        public decimal? Value { get; set; }
        public string Footnote { get; set; }

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
            Tag = entries[i++];
            Version = entries[i++];
            Coreg = entries[i++];
            Ddate = YYYYMMDD.Parse(entries[i++]);
            Qtrs = int.Parse(entries[i++]);
            Uom = entries[i++];
            Value = (entries[i] == "" ? null : (decimal?)decimal.Parse(entries[i])); i++;
            Footnote = entries[i++];
            
            return true;
        }

        public override string ToString()
        {
            if (Value.HasValue)
            {
                return string.Format("{0} = {1:n} [{2} Qs] on {3}", Tag, Value, Qtrs, Ddate);
            }
            else
            {
                return string.Format("{0} = ? [{1} Qs] on {2}", Tag, Qtrs, Ddate);
            }
        }
    }
}
