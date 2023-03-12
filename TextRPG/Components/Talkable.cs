using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Static;

namespace TextRPG.Components
{
    public class Talkable : Interactable
    {
        public Talkable(string objectID) : base(objectID)
        {
        }

        public void Description(Controller controller)
        {
            controller.PrintLine(Get(Text.Description));
        }
    }
}
