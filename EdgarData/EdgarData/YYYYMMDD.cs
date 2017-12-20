using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarData
{
    public class YYYYMMDD : IComparable<YYYYMMDD>, IComparable
    {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }

        public YYYYMMDD(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public static YYYYMMDD Parse(string value)
        {
            if (value == string.Empty)
                return null;

            return new YYYYMMDD(
                int.Parse(value.Substring(0, 4)),
                int.Parse(value.Substring(4, 2)),
                int.Parse(value.Substring(6, 2))
                );
        }

        public int CompareTo(YYYYMMDD other)
        {
            int year = Year.CompareTo(other.Year);

            if (year != 0)
                return year;

            int month = Month.CompareTo(other.Month);

            if (month != 0)
                return month;

            int day = Day.CompareTo(other.Day);

            return day;
        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj as YYYYMMDD);
        }

        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;

            var o = obj as YYYYMMDD;

            if (null == o)
                return false;

            return Year == o.Year && Month == o.Month && Day == o.Day;
        }

        public override string ToString()
        {
            return string.Format("{0:D4}-{1:D2}-{2:D2}", Year, Month, Day);
        }
    }
}
