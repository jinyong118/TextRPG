using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

using TextRPG;
using TextRPG.Menu;

namespace TestPlay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameObject.MakeAllObjects2();

#pragma warning disable CA1416 // Validate platform compatibility
            Console.WindowWidth = 54;
            Console.WindowHeight = 48;
            Console.BufferWidth = 54;
            Console.BufferHeight = 108;
#pragma warning restore CA1416 // Validate platform compatibility

            User user = new(MainMenu.one);

            user.Control();
        }

        public int func<T>(T t)
        {



            return 0;
        }
    }
}
