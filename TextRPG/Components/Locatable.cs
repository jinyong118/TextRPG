using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Static;

namespace TextRPG.Components
{
    public class Locatable : Interactable
    {
        public Locatable(string objectID) : base(objectID)
        {
        }

        public void Description(Controller controller)
        {
            GameObject? character = controller.Character;
            if (character == null)
            {
                return;
            }
            Move? move = character.GetComponent<Move>();
            if (move == null)
            {
                return;
            }
            IParentNode parentNode = move;
            GameObject location = move.Location;
            move.Location = (parentNode.GetCurNode(controller) as Locatable)?.gameObject ?? location;
            controller.Print("연결된 곳 :");
            UI.ShowList(parentNode.GetLabels(controller));
            UI.EraseLines();
            Explore? explore = character.GetComponent<Explore>();
            if (explore == null)
            {
                return;
            }
            parentNode = explore;
            controller.Print("탐색 대상 :");
            UI.ShowList(parentNode.GetLabels(controller));
            move.Location = location;
        }
    }
}
