using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Static;

namespace TextRPG.Components
{
    public class Playable : Interactable
    {
        public Playable(string objectID) : base(objectID)
        {
        }

        protected override IChildNode[]? GetInteractions()
        {
            if (gameObject == null)
            {
                UI.SystemMessage($"\"{gameObjectID}\" GameObject not exist.");
                return null;
            }
            return gameObject.GetComponents<Interaction>();
        }
    }
}
