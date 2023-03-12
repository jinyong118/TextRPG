using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Static;

namespace TextRPG.Components
{
    public class Bag : Connection
    {
        public Bag(string objectID) : base(objectID)
        {
        }

        protected override IChildNode[]? GetInteractables()
        {
            if (gameObject == null)
            {
                UI.SystemMessage($"\"{gameObjectID}\" GameObject not exist.");
                return null;
            }
            var list = from obj in gameObject.LinkedObjects
                       where obj.IsContain<Inventoriable>()
                       select obj.GetComponent<Inventoriable>();
            return list.ToArray();
        }
    }
}
