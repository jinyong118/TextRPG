using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Static
{
    public static class Time
    {
        public static string Clock => $"{Day,2}D {Hour:D2}:{Min:D2}";
        public static int Day => NowTime / 60 / 24;
        public static int Hour => NowTime / 60 % 24;
        public static int Min => NowTime % 60;
        public static int NowTime => time;

        private static int time = 0;
        const int unit = 12;

        public static void GoTime(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                time += unit;
            }
        }
        public static void SetTime(int time)
        {
            Time.time = time;
        }
    }
}
