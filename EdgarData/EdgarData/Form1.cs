using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdgarData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;

            Dictionary<string, int> Tags = new Dictionary<string, int>();

            using (var fs = File.OpenRead(@"C:\Users\Shaun\Downloads\2017q3\num.txt"))
            {
                using (var sr = new StreamReader(fs, Encoding.UTF8))
                {
                    NumEntry entry = new NumEntry();
                    entry.ReadHeading(sr);

                    bool more = true;

                    while(more)
                    {
                        more = entry.ReadEntry(sr);

                        if (more)
                        {
                            count++;
                            
                            if(Tags.ContainsKey(entry.Tag))
                            {
                                Tags[entry.Tag]++;
                            }
                            else
                            {
                                Tags[entry.Tag] = 1;
                            }
                        }
                    }
                }
            }

            
        }

        private List<T> LoadEntries<T>(string path) where T : LoadableEntry, new()
        {
            List<T> results = new List<T>();

            using (var fs = File.OpenRead(path))
            {
                using (var sr = new StreamReader(fs, Encoding.UTF8))
                {
                    T entry = new T();
                    entry.ReadHeading(sr);

                    bool continueFlag = true;
                    while(continueFlag)
                    {
                        entry = new T();
                        continueFlag = entry.ReadEntry(sr);
                        if(continueFlag)
                        {
                            results.Add(entry);
                        }
                    }
                }
            }

            return results;
        }

        private List<SubEntry> SubEntries;
        private List<NumEntry> NumEntries;

        private void button2_Click(object sender, EventArgs evts)
        {
            SubEntries = LoadEntries<SubEntry>(@"C:\Users\Shaun\Downloads\2017q3\sub.txt");
            NumEntries = LoadEntries<NumEntry>(@"C:\Users\Shaun\Downloads\2017q3\num.txt");

            SubEntries = SubEntries.OrderBy(s => s.Name).ToList();

            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("Subs");

            dt.Columns.Add("Name");
            dt.Columns.Add("Fye");
            var adsh = dt.Columns.Add("Adsh");

            SubEntries.ForEach((e) =>
            {
                var row = dt.NewRow();
                row["Name"] = e.Name;
                row["Fye"] = e.Fye;
                row["Adsh"] = e.Adsh;
                
                dt.Rows.Add(row);
            });

            this.subsGrid.DataSource = ds;
            this.subsGrid.DataMember = "Subs";
            //subsGrid.Columns[1].Visible = false;
            this.subsGrid.Refresh();
        }

        public static string EscapeLikeValue(string valueWithoutWildcards)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < valueWithoutWildcards.Length; i++)
            {
                char c = valueWithoutWildcards[i];
                if (c == '*' || c == '%' || c == '[' || c == ']')
                    sb.Append("[").Append(c).Append("]");
                else if (c == '\'')
                    sb.Append("''");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private void filter_TextChanged(object sender, EventArgs e)
        {
            //if (filter.Text.Length == 0)
            //{
            //    (subsGrid.DataSource as DataSet).Tables["Subs"].DefaultView.RowFilter = null;
            //}
            //else
            //{
            //    (subsGrid.DataSource as DataSet).Tables["Subs"].DefaultView.RowFilter = "Name LIKE '*" + EscapeLikeValue(filter.Text) + "*'";
            //}

            //subsGrid.

            //return;

            subsGrid.CurrentCell = null;
            var dataSet = subsGrid.DataSource as DataSet;

            bool showAll = filter.Text.Length < 3 || filter.Text.Trim() == string.Empty;
            string filterText = filter.Text.ToLowerInvariant();

            for(int r = 0; r < subsGrid.Rows.Count; r++)
            {
                var row = subsGrid.Rows[r];
                if (showAll)
                {
                    row.Visible = true;
                }
                else
                {
                    var view = row.DataBoundItem as DataRowView;
                    var name = view.Row["Name"].ToString();

                    row.Visible = name.ToLowerInvariant().Contains(filterText);
                }
            }

        }

        private void subsGrid_SelectionChanged(object sender, EventArgs evts)
        {
            if (subsGrid.SelectedCells.Count > 0)
            {
                var selectedCell = subsGrid.SelectedCells[0];
                var view = selectedCell.OwningRow.DataBoundItem as DataRowView;
                var adsh = view.Row["Adsh"].ToString();

                DataSet ds = new DataSet("Nums");
                DataTable dt = ds.Tables.Add("Nums");

                dt.Columns.Add("Tag");
                dt.Columns.Add("Value");
                dt.Columns.Add("Ddate");
                dt.Columns.Add("Qtrs");
                dt.Columns.Add("Adsh");

                foreach(var entry in NumEntries.Where(e => e.Adsh == adsh))
                {
                    var row = dt.NewRow();
                    row["Tag"] = entry.Tag;
                    row["Value"] = entry.Value;
                    row["Ddate"] = entry.Ddate;
                    row["Qtrs"] = entry.Qtrs;
                    row["Adsh"] = entry.Adsh;

                    dt.Rows.Add(row);
                }

                this.numsGrid.DataSource = ds;
                this.numsGrid.DataMember = "Nums";
                this.numsGrid.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs evts)
        {
            EdgarDataSet eds = new EdgarData.EdgarDataSet(@"C:\Users\Shaun\Downloads\2017q3.zip");

            var brka = eds.Subs.Where(e => e.Ticker == "MSFT").First();

            var nums = eds.Nums.Where(e => e.Adsh == brka.Adsh && e.Tag == "NetIncomeLoss" && e.Ddate.Year == 2016 && e.Qtrs == 1);

            var total = nums.Select(n => n.Value).Aggregate((a, b) =>
            {
                return a + b;
            });

            var ynums = eds.Nums.Where(e => e.Adsh == brka.Adsh && e.Tag == "NetIncomeLoss" && e.Ddate.Year == 2016 && e.Qtrs == 4);
        }
    }
}
