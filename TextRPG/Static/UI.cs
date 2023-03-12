using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Static
{
    public struct CharBlock
    {
        int width;
        readonly char unit = '─';

        readonly StringBuilder sb;

        public CharBlock()
        {
            width = Console.BufferWidth;
            sb = new StringBuilder();
            for (int i = 0; i < width; i++)
            {
                sb.Append(unit);
            }
        }
        public CharBlock(char c)
        {
            unit = c;
            width = Console.BufferWidth;
            sb = new StringBuilder();
            for (int i = 0; i < width; i++)
            {
                sb.Append(unit);
            }
        }

        public string Get(int width)
        {
            if (this.width == width)
            {
                return sb.ToString();
            }
            else if (this.width > width)
            {
                sb.Remove(width, this.width - width);
                this.width = width;
                return sb.ToString();
            }
            else
            {
                for (int i = 0; i < width - this.width; i++)
                {
                    sb.Append(unit);
                }
                this.width = width;
                return sb.ToString();
            }
        }

        public void Test()
        {
            Console.WriteLine(width);
            Console.WriteLine(unit);
            Console.WriteLine(sb.ToString());
        }
    }
    public struct TextColor
    {
        public ConsoleColor fore = ConsoleColor.Gray;
        public ConsoleColor back = ConsoleColor.Black;

        public TextColor(ConsoleColor fore, ConsoleColor back)
        {
            this.fore = fore;
            this.back = back;
        }

        public readonly static TextColor normal = new TextColor(ConsoleColor.Gray, ConsoleColor.Black);
        public readonly static TextColor invert = new TextColor(ConsoleColor.Black, ConsoleColor.White);

        //public static bool operator ==(TextColor l, TextColor r)
        //{
        //    return (l.fore == r.fore) && (l.back == r.back);
        //}
        //public static bool operator !=(TextColor l, TextColor r)
        //{
        //    return (l.fore == r.fore) || (l.back == r.back);
        //}
    }

    public static class UI
    {
        static readonly CharBlock divider = new('━');
        static readonly CharBlock space = new(' ');

        public static void DrawDivider(int line = 1)
        {
            for (int i = 0; i < line; i++)
            {
                Console.WriteLine(divider.Get(Console.BufferWidth));
            }
        }
        public static void EraseLines(int line = 1)
        {
            if (Console.CursorTop - line < 0)
            {
                line = Console.CursorTop;
            }
            int top = Console.CursorTop -= line;
            for (int i = 0; i < line; i++)
            {
                Console.Write(space.Get(Console.BufferWidth));
                Console.SetCursorPosition(0, ++top);
            }
            Console.SetCursorPosition(0, Console.CursorTop - line);
        }

        public static void Write(string str, TextColor color = default, bool indentation = true)
        {
            if (indentation)
            {
                Console.Write(' ');
            }
            bool isDefault = color.fore == ConsoleColor.Black && color.back == ConsoleColor.Black;
            if (!isDefault)
            {
                Console.ForegroundColor = color.fore;
                Console.BackgroundColor = color.back;
            }
            Console.Write(str);
            if (!isDefault)
            {
                Console.ForegroundColor = TextColor.normal.fore;
                Console.BackgroundColor = TextColor.normal.back;
            }
            return;
        }
        public static void WriteEnter(string str, TextColor color = default, bool indentation = true)
        {
            Write(str + '\n', color, indentation);
        }
        public static void WriteLine(string str, TextColor color = default, bool indentation = true)
        {
            WriteEnter(str, color, indentation);
            DrawDivider();
        }

        public static void SystemMessage(string str)
        {
            Cursor.Check();
            WriteLine(str);
            WriteLine("확인", TextColor.invert);
            Console.ReadKey(true);
            Cursor.Back();
            //Console.Beep();
        }

        public static void ShowList(string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (Console.CursorLeft + GetStringLength(list[i]) + 2 > Console.WindowWidth - 1)
                {
                    Console.WriteLine();
                }
                else if (i != 0)
                {
                    Console.Write(" |");
                }
                Write(list[i]);
            }
            Console.WriteLine();
            DrawDivider();
        }
        public static void ShowCurrentSelection(string[] list, int index)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (Console.CursorLeft + GetStringLength(list[i]) + 2 >= Console.WindowWidth - 1)
                {
                    Console.WriteLine();
                }
                else if (i != 0)
                {
                    Console.Write(" |");
                }
                Write(list[i], i == index ? TextColor.invert : TextColor.normal);
            }
            Console.WriteLine();
            DrawDivider();
        }

        public static int GetStringLength(string str)
        {
            char[] charObj = str.ToCharArray();
            int maxLength = 0;

            for (int i = 0; i < charObj.Length; i++)
            {
                byte oF = (byte)((charObj[i] & 0xff00) >> 7);

                if (oF == 0)
                {
                    maxLength++;
                }
                else
                {
                    maxLength += 2;
                }
            }
            return maxLength;
        }
    }
}
