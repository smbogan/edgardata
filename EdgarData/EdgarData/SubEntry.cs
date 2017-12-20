using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarData
{
    public class SubEntry : LoadableEntry
    {
        public string Adsh { get; set; }
        public string Cik { get; set; }
        public string Name { get; set; }
        public string Sic { get; set; }
        public string Countryba { get; set; }
        public string Stprba { get; set; }
        public string Cityba { get; set; }
        public string Zipba { get; set; }
        public string Bas1 { get; set; }
        public string Bas2 { get; set; }
        public string Baph { get; set; }
        public string Countryma { get; set; }
        public string Stprma { get; set; }
        public string Cityma { get; set; }
        public string Zipma { get; set; }
        public string Mas1 { get; set; }
        public string Mas2 { get; set; }
        public string Countryinc { get; set; }
        public string Stprinc { get; set; }
        public string Ein { get; set; }
        public string Former { get; set; }
        public string Changed { get; set; }
        public string Afs { get; set; }
        public string Wksi { get; set; }
        public string Fye { get; set; }
        public string Form { get; set; }
        public string Period { get; set; }
        public string Fy { get; set; }

        public string Fp { get; set; }
        public string Filed { get; set; }
        public string Accepted { get; set; }
        public string Prevrpt { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public string Nciks { get; set; }
        public string Aciks { get; set; }


        //Dynamically Calculated Properties
        public string Ticker
        {
            get
            {
                return new string(Instance.TakeWhile(c => c != '-' && c != '_').ToArray()).ToUpperInvariant();
            }
        }

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
            Cik = entries[i++];
            Name = entries[i++];
            Sic = entries[i++];
            Countryba = entries[i++];
            Stprba = entries[i++];
            Cityba = entries[i++];
            Zipba = entries[i++];
            Bas1 = entries[i++];
            Bas2 = entries[i++];
            Baph = entries[i++];
            Countryma = entries[i++];
            Stprma = entries[i++];
            Cityma = entries[i++];
            Zipma = entries[i++];
            Mas1 = entries[i++];
            Mas2 = entries[i++];
            Countryinc = entries[i++];
            Stprinc = entries[i++];
            Ein = entries[i++];
            Former = entries[i++];
            Changed = entries[i++];
            Afs = entries[i++];
            Wksi = entries[i++];
            Fye = entries[i++];
            Form = entries[i++];
            Period = entries[i++];
            Fy = entries[i++];
            Fp = entries[i++];
            Filed = entries[i++];
            Accepted = entries[i++];
            Prevrpt = entries[i++];
            Detail = entries[i++];
            Instance = entries[i++];
            Nciks = entries[i++];
            Aciks = entries[i++];

            return true;
        }

        public override string ToString()
        {
            if (Name != null)
                return Name;

            return "<unnamed>";
        }
    }
}
