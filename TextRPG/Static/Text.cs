using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Static
{
    public static class Text
    {
        public const string gameObject = "gameObject";
        public const string Component = "Component";
        public const string Components = "Components";
        public const string Move = "Move";
        public const string Explore = "Explore";
        public const string AsPlace = "AsPlace";
        public const string PositionChanger = "PositionChanger";
        public const string Bag = "Bag";
        public const string AsStreet = "AsStreet";
        public const string Label = "Label";
        public const string Descriptable = "Descriptable";
        public const string LinkedObjects = "LinkedObjects";
        public const string Location = "Location";
        public const string Information = "Information";
        public const string Nothing = "Nothing";
        public const string Description = "Description";
        public const string Target = "Target";
        public const string Drinkable = "Drinkable";
        public const string Property = "Property";
        public const string Scripts = "Scripts";


        private readonly static Dictionary<string, string> data = new();

        static Text()
        {
            string path = DataReader.Path + @"\Translation.txt";
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split('=');
                data.Add(line[0], line[1]);
            }
        }

        public static string GetKR(string en)
        {
            return data.ContainsKey(en) ? data[en] : en;
        }
    }
}
