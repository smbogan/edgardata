using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EdgarData
{
    public class EdgarDataSet
    {
        private List<SubEntry> subs;
        private List<NumEntry> nums;
        private List<TagEntry> tags;
        private List<PreEntry> pres;

        public IEnumerable<SubEntry> Subs
        {
            get
            {
                foreach (var s in subs)
                    yield return s;
            }
        }

        public IEnumerable<NumEntry> Nums
        {
            get
            {
                foreach (var n in nums)
                    yield return n;
            }
        }

        public IEnumerable<TagEntry> Tags
        {
            get
            {
                foreach (var t in tags)
                    yield return t;
            }
        }

        public IEnumerable<PreEntry> Pres
        {
            get
            {
                foreach (var p in pres)
                    yield return p;
            }
        }

        public EdgarDataSet(string zipPath)
        {
            using (var zipArchiveStream = File.OpenRead(zipPath))
            {
                using (var zipArchive = new System.IO.Compression.ZipArchive(zipArchiveStream, System.IO.Compression.ZipArchiveMode.Read))
                {
                    var subFileEntry = zipArchive.Entries.Where(e => e.FullName.EndsWith("sub.txt")).First();
                    var numFileEntry = zipArchive.Entries.Where(e => e.FullName.EndsWith("num.txt")).First();
                    var tagFileEntry = zipArchive.Entries.Where(e => e.FullName.EndsWith("tag.txt")).First();
                    var preFileEntry = zipArchive.Entries.Where(e => e.FullName.EndsWith("pre.txt")).First();

                    subs = LoadEntries<SubEntry>(subFileEntry.Open()).OrderBy(e => e.Name).ToList();
                    nums = LoadEntries<NumEntry>(numFileEntry.Open());
                    tags = LoadEntries<TagEntry>(tagFileEntry.Open());
                    pres = LoadEntries<PreEntry>(preFileEntry.Open());

                    
                }
            }
        }

        private List<T> LoadEntries<T>(Stream fileStream) where T : LoadableEntry, new()
        {
            List<T> results = new List<T>();

            using (var sr = new StreamReader(fileStream, Encoding.UTF8))
            {
                T entry = new T();
                entry.ReadHeading(sr);

                bool continueFlag = true;
                while (continueFlag)
                {
                    entry = new T();
                    continueFlag = entry.ReadEntry(sr);
                    if (continueFlag)
                    {
                        results.Add(entry);
                    }
                }
            }
            

            return results;
        }
    }
}
