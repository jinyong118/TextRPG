using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;

namespace TextRPG.Menu
{
    public partial class MainMenu
    {
        public static readonly MainMenu one = new();

        private MainMenu()
        {
            ChildNodes = new IChildNode[] { NewGame.one, Continue.one, Setting.one, ExitGame.one };
        }
    }

    partial class MainMenu : IParentNode
    {
        public int Index { get; set; } = 0;

        public IChildNode[]? ChildNodes { get; protected set; }

        public Action<Controller>? WhenEnter { get; protected set; } = null;
        public Action<Controller>? WhenExit { get; protected set; } = null;
    }
}
