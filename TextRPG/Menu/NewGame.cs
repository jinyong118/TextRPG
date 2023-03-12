using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Components;
using TextRPG.Interface;
using TextRPG.Static;

namespace TextRPG.Menu
{
    public partial class NewGame
    {
        public static readonly NewGame one = new();

        private NewGame()
        {
            Label = nameof(NewGame);
            PassCheckFunc = (controller) => true;
            ShowInformation = (controller) => controller.PrintLine("Play new game.");
            ShowPreview = (controller) => controller.PrintLine("Preview");
            SelectThis = Select;
        }

        public GameObject MakeNewCharacter(string name)
        {
            string path = DataReader.Path + @"\InitCharacter.txt";
            Dictionary<string, string> textData = DataReader.ReadData(path);
            textData["name"] = name;
            GameObject character = new(textData);
            return character;
        }

        void Select(Controller controller)
        {
            controller.Cancle();
            controller.SetCharacter(MakeNewCharacter("Player"));
            if (controller.Character != null)
            {
                IParentNode? parent = controller.Character.GetComponent<Playable>();
                if (parent != null)
                {
                    controller.SetInitNode(parent);
                }
                else
                {
                    Console.WriteLine("no parent");
                    Console.ReadKey(true);
                }
            }
        }
    }

    partial class NewGame : IChildNode
    {
        public string Label { get; protected set; }

        public Func<Controller, bool> PassCheckFunc { get; protected set; }

        public Action<Controller>? ShowInformation { get; protected set; }
        public Action<Controller>? ShowPreview { get; protected set; }
        public Action<Controller>? SelectThis { get; protected set; }
    }
}
