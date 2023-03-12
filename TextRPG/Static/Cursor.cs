using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Static
{
    public static class Cursor
    {
        private static readonly Stack<int> CursorStack = new();
        public static int Distance => Console.CursorTop - (CursorStack.TryPop(out int check) ? check : Console.CursorTop);

        public static void Check()
        {
            CursorStack.Push(Console.CursorTop);
        }
        public static void Back(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                UI.EraseLines(Distance);
            }
        }
        public static void Clear()
        {
            CursorStack.Clear();
        }
    }
}
