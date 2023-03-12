using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Static;

namespace TextRPG.Components
{
    public abstract class Conversation : Interaction
    {
        protected Conversation(string objectID) : base(objectID)
        {
        }
    }

    public class Talk : Conversation
    {
        public Talk(string objectID) : base(objectID)
        {
        }

        public override void Preview(Controller controller)
        {
            if (gameObject?.GetComponent<Talkable>() is not Talkable talkable)
            {
                UI.SystemMessage($"\"{gameObjectID}\" GameObject have no \"{nameof(Talkable)}\" Component.");
                return;
            }
            controller.PrintLine($"{talkable.Label}(와)과 대화한다.");
        }

        public override void Select(Controller controller)
        {
            controller.ReadScripts(Gets(Text.Scripts));
            if (gameObject?.GetComponent<Talkable>() is not Talkable talkable)
            {
                UI.SystemMessage($"\"{gameObjectID}\" GameObject have no \"{nameof(Talkable)}\" Component.");
                return;
            }
            controller.Log($"{talkable.Label}(와)과 대화했다.");
        }
    }
}
