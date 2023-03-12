using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Static;

namespace TextRPG.Components
{
    public class Reach : Interaction
    {
        public Reach(string objectID) : base(objectID)
        {
        }

        public override void Information(Controller controller)
        {
            //GameObject? character = controller.Character;
            //if (character == null)
            //{
            //    return;
            //}
            //Move? move = character.GetComponent<Move>();
            //if (move == null)
            //{
            //    return;
            //}
            //IParentNode parentNode = move;
            //GameObject location = move.Location;
            //move.Location = (parentNode.GetCurNode(controller) as Locatable)?.gameObject ?? location;
            //controller.Print("연결된 곳 :");
            //UI.ShowList(parentNode.GetLabels(controller));
            //UI.EraseLines();
            //Explore? explore = character.GetComponent<Explore>();
            //if (explore == null)
            //{
            //    return;
            //}
            //parentNode = explore;
            //controller.Print("탐색 대상 :");
            //UI.ShowList(parentNode.GetLabels(controller));
            //move.Location = location;
        }
        public override void Preview(Controller controller)
        {
            if (gameObject?.GetComponent<Locatable>() is not Locatable locatable)
            {
                UI.SystemMessage($"\"{gameObjectID}\" GameObject have no \"{nameof(Locatable)}\" Component.");
                return;
            }
            controller.PrintLine($"{locatable.Label}(으)로 이동한다.");
        }
        public override void Select(Controller controller)
        {
            if (controller.Character is not GameObject character)
            {
                UI.SystemMessage($"\"{controller.GetType().Name}\" Class have no \"{nameof(controller.Character)}\" GameObject.");
                return;
            }
            if (character.GetComponent<Move>() is not Move move)
            {
                UI.SystemMessage($"\"{character.ID}\" GameObject have no \"{nameof(Move)}\" Component.");
                return;
            }
            if (gameObject == null)
            {
                return;
            }
            move.Location = gameObject;
            if (gameObject.GetComponent<Locatable>() is not Locatable locatable)
            {
                return;
            }
            controller.Log($"{locatable.Label}(으)로 이동했다.");
            controller.Cancle();
        }
    }
}
