using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Static;
using TextRPG.Components;

namespace TextRPG
{
    public class User : Controller
    {
        public User(IParentNode init) : base(init)
        {
        }

        public override void Control()
        {
            while (true)
            {
                IParentNode parent = Pop();
                RenewalScreen();
                SelectOne(parent)?.SelectThis?.Invoke(this);
            }
        }
        public override void Cancle(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                IParentNode higher = Pop();
                higher.Index = 0;
            }
        }

        public void RenewalScreen()
        {
            Console.Clear();
            UI.DrawDivider();

            var reverse = nodeStack.Reverse();

            if (Character != null)
            {
                Print($"현재 위치: {Character.GetComponent<Move>()?.Location.GetComponent<Locatable>()?.Label}");
                Console.CursorLeft = Console.WindowWidth - 11;
                PrintLine(Time.Clock);
                PrintLine($"이름: {Character.Name}");
                //PrintLine(Character.GetComponent<Status>().GetFullString());
            }
            //UI.ShowList(PassList.ToArray());
            foreach (IParentNode higher in reverse)
            {
                UI.ShowCurrentSelection(higher.GetLabels(this), higher.Index);
                higher.GetCurNode(this).ShowInformation?.Invoke(this);
            }
        }

        public override IChildNode? SelectOne(IParentNode parent)
        {
            bool? arrow = null;
            if (parent.GetCurNode(this).Label == Nothing.One.Label)
            {
                return null;
            }
            while (arrow != false)
            {
                Cursor.Check();
                UI.ShowCurrentSelection(parent.GetLabels(this), parent.Index);
                parent.GetCurNode(this).ShowInformation?.Invoke(this);
                Cursor.Check();
                AddPass(parent.GetCurNode(this).GetType().Name);
                parent.GetCurNode(this).ShowPreview?.Invoke(this);
                RemovePass(parent.GetCurNode(this).GetType().Name);
                arrow = MoveArrow(parent);
                Cursor.Back();
                if (arrow == null)
                {
                    Cursor.Back();
                }
                else
                {
                    Cursor.Clear();
                    Push(parent);
                    if (arrow == true)
                    {
                        return parent.GetCurNode(this);
                    }
                    else
                    {
                        Cancle();
                        parent.WhenExit?.Invoke(this);
                        return null;
                    }
                }
            }
            return null;
        }
        public override bool? MoveArrow(IParentNode parent)
        {
            int length = parent.GetLabels(this).Length - 1;

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (parent.Index-- == 0)
                        {
                            parent.Index = length;
                        }
                        return null;
                    case ConsoleKey.RightArrow:
                        if (parent.Index++ == length)
                        {
                            parent.Index = 0;
                        }
                        return null;
                    case ConsoleKey.UpArrow:
                        parent.Index = 0;
                        return false;
                    case ConsoleKey.DownArrow:
                        return true;
                    default:
                        break;
                }
            }
        }

        public override void Print(string str)
        {
            UI.Write(str);
        }
        public override void PrintEnter(string str)
        {
            UI.WriteEnter(str);
        }
        public override void PrintLine(string str)
        {
            UI.WriteLine(str);
        }

        public override void ReadScripts(string[] script)
        {
            for (int i = 0; i < script.Length; i++)
            {
                UI.SystemMessage(script[i]);
            }
        }

        public override void Log(string str)
        {
            UI.SystemMessage(str);
        }

        public override void NotYet()
        {
            UI.SystemMessage("Not Yet");
            Cancle();
        }
    }
}
