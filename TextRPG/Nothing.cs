using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Static;

namespace TextRPG.Components
{
    public class Nothing : Interaction
    {
        public static readonly Nothing One = new("-1");
        public static readonly IChildNode[] Array = new IChildNode[] { One };

        public Nothing(string objectID) : base(objectID)
        {
        }

        public override void Preview(Controller controller)
        {
        }
        public override void Select(Controller controller)
        {
            controller.Cancle();
        }
    }
}
