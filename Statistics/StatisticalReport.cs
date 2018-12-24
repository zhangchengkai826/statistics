using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace Statistics
{
    public enum StatisticFigureType
    {
        Mean, Variance, StandardDeviation, Covariance, CorrelationCoefficient
    }
    public struct StatisticFigure
    {
        public StatisticFigureType type;
        public string[] parameters;
        public double value;
        public override string ToString()
        {
            return "Statistic Type: " + type + "  Params: " + string.Join(" ", parameters);
        }
    }
    class StatisticalReport:ISavable
    {
        private string title;
        public string Title { get => title; }
        private DateTime timeStamp;
        public DateTime TimeStamp { get => timeStamp; }
        private StatisticFigure[] stats;
        public StatisticFigure[] Stats { get => stats; }
        private Stopwatch sw;
        public StatisticalReport(string title, StatisticFigure[] stats)
        {
            this.title = title;
            timeStamp = DateTime.Now;
            this.stats = stats;
        }
        public void Save(string fileName)
        {
            Task.Run(() =>
            {
                sw = Stopwatch.StartNew();
                string ext = fileName.Split('.')[1];
                switch (ext)
                {
                    case "txt":
                        SaveToTXT(fileName);
                        break;
                    case "xml":
                        SaveToXML(fileName);
                        break;
                    case "json":
                        SaveToJSON(fileName);
                        break;
                }
                sw.Stop();
                MessageBox.Show(String.Format(@"Save success [Time elapsed: {0}s]", (double)sw.ElapsedMilliseconds / 1000.0));
            });
        }
        private void SaveToTXT(string fileName)
        {
            using(StreamWriter sw = new StreamWriter(fileName)) {
                foreach (StatisticFigure s in stats)
                {
                    string block = String.Format("Statistic Type:  {0}\r\nParameters:  {1}\r\nValue:  {2}\r\n\r\n", s.type, String.Join("  ", s.parameters), s.value);
                    sw.Write(block);
                }
            }
        }
        private void SaveToXML(string fileName)
        {
            XmlDocument d = new XmlDocument();
            XmlElement root = d.CreateElement("report");
            foreach (StatisticFigure s in stats)
            {
                XmlElement n = d.CreateElement("statistic");
                n.AppendChild(d.CreateElement("type", s.type.ToString()));
                foreach(string p in s.parameters)
                {
                    n.AppendChild(d.CreateElement("param", p));
                }
                n.AppendChild(d.CreateElement("value", s.value.ToString()));
                root.AppendChild(n);
            }
            d.AppendChild(root);
            d.Save(fileName);
        }
        private void SaveToJSON(string fileName)
        {
            string jsonStr = JsonConvert.SerializeObject(stats, Newtonsoft.Json.Formatting.Indented);
            using (StreamWriter file = File.CreateText(fileName))
            {
                file.Write(jsonStr);
            }
        }
    }
}
