using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Static;

namespace TextRPG.Components
{
    public class Description : Interaction
    {
        public Description(string objectID) : base(objectID)
        {
        }

        public override void Information(Controller controller)
        {
            string[] target = Get(Text.Target).Split('.');
            if (gameObject?.GetComponent(target[0]) is not Component component)
            {
                UI.SystemMessage($"\"{gameObjectID}\" GameObject have no \"{target[0]}\" Component.");
                return;
            }
            if (component.GetType().GetMethod(target[1]) is not MethodInfo methodInfo)
            {
                UI.SystemMessage($"\"{component.GetType().Name}\" Component have no \"{target[1]}\" Method.");
                return;
            }
            methodInfo.Invoke(component, new object[] { controller });
        }
        public override void Preview(Controller controller)
        {
        }
        public override void Select(Controller controller)
        {
        }
    }
}
