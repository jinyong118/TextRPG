using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Static;

namespace TextRPG.Menu
{
    public partial class ExitGame
    {
        public static readonly ExitGame one = new();

        private ExitGame()
        {
            Label = nameof(ExitGame);
            PassCheckFunc = (controller) => true;
            ShowInformation = (controller) => controller.PrintLine("Exit Game.");
            ShowPreview = null;
            SelectThis = EndGame;
        }

        private void EndGame(Controller controller)
        {
            UI.SystemMessage("Exit game.");
            Environment.Exit(0);
        }
    }

    partial class ExitGame : IChildNode
    {
        public string Label { get; protected set; }

        public Func<Controller, bool> PassCheckFunc { get; protected set; }

        public Action<Controller>? ShowPreview { get; protected set; }
        public Action<Controller>? ShowInformation { get; protected set; }
        public Action<Controller>? SelectThis { get; protected set; }
    }
}
