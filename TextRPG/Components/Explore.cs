using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Static;

namespace TextRPG.Components
{
    public class Explore : Connection
    {
        public Explore(string objectID) : base(objectID)
        {
        }

        protected override IChildNode[]? GetInteractables()
        {
            if (gameObject?.GetComponent<Move>() is not Move move)
            {
                UI.SystemMessage($"\"{gameObjectID}\" GameObject have no \"{nameof(Move)}\" Component.");
                return null;
            }
            var list = from obj in move.Location.LinkedObjects
                       where obj.IsContain<Talkable>()
                       select obj.GetComponent<Talkable>();
            return list.ToArray();
        }
    }
}
