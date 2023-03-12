using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Static;

namespace TextRPG.Components
{
    public class Move : Connection
    {
        public GameObject Location
        {
            get => GameObject.Find(Get(Text.Location)) ?? gameObject;
            set => Set(Text.Location, value?.ID ?? "-1");
        }

        public Move(string objectID) : base(objectID)
        {
        }

        protected override IChildNode[]? GetInteractables()
        {
            var list = from obj in Location.LinkedObjects
                       where obj.IsContain<Locatable>()
                       select obj.GetComponent<Locatable>();
            return list.ToArray();
        }
        //protected override IChildNode[]? GetInteractables()
        //{
        //    var list = from obj in Location.LinkedObjects
        //               where obj.IsContain<Reach>()
        //               select obj.GetComponent<Reach>();
        //    return list.ToArray();
        //}
    }


}
