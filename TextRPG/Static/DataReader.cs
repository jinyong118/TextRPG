using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Static
{
    public static class DataReader
    {
        public static string Path => Directory.GetCurrentDirectory() + @"\DataFiles";
        private static readonly StringBuilder sb = new();

        public static Dictionary<string, string> ReadData(string path)
        {
            string[] lines = File.ReadAllLines(path);

            Dictionary<string, string> data = new();

            foreach (string line in lines)
            {
                string label = line.Split('=')[0];
                string content = line.Split('=')[1];
                data.Add(label, content);
            }

            return data;
        }
        public static List<Dictionary<string, string>> GetData(string path)
        {
            string[] lines = File.ReadAllLines(path);
            List<Dictionary<string, string>> data = new();
            foreach (string line in lines)
            {
                string[] obj = line.Split('\t');
                Dictionary<string, string> one = new();
                foreach (string item in obj)
                {
                    string[] set = item.Split('=');
                    string label = set[0];
                    string content = set[1];
                    one.Add(label, content);
                }
                data.Add(one);
            }
            return data;
        }

        public static string[] Trim(string line)
        {
            return (from text in line.Split('/')
                    select text.Trim()).ToArray();
        }
        public static string Combine(string[] lines)
        {
            sb.Clear();
            for (int i = 0; i < lines.Length; i++)
            {
                sb.Append(lines[i] + (i < lines.Length - 1 ? '/' : string.Empty));
            }
            return sb.ToString();
        }

        public static string[] GetFilePahts(string className)
        {
            string path = Path;

            return Directory.GetFiles($"{path}\\{className}");
        }
    }
}
