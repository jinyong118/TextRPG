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
    public abstract partial class Connection : Interaction
    {
        public Connection(string objectID) : base(objectID)
        {
            WhenEnter += (controller) => controller.AddPass(GetType().Name);
            WhenExit += (controller) => controller.RemovePass(GetType().Name);
        }

        protected abstract IChildNode[]? GetInteractables();
        //protected virtual IChildNode[]? GetInteractables()
        //{
        //    if (Type.GetType("TextRPG.GameObject") is not Type type)
        //    {
        //        return null;
        //    }
        //    if (type.GetProperty(Get(Text.Property)) is not PropertyInfo propertyInfo)
        //    {
        //        return null;
        //    }
        //    if (GameObject.Find(Get("TargetID")) is not GameObject targetObject)
        //    {
        //        return null;
        //    }
        //    if (propertyInfo.GetValue(targetObject) is not GameObject gameObject)
        //    {
        //        return null;
        //    }
        //    var list = from obj in gameObject.LinkedObjects
        //               where obj.IsContain(Get(Text.Target))
        //               select obj.GetComponent(Get(Text.Target)) as IChildNode;
        //    return list.ToArray();
        //}

        public override void Preview(Controller controller)
        {
            UI.ShowList((this as IParentNode).GetLabels(controller));
        }
        public override void Select(Controller controller)
        {
            WhenEnter?.Invoke(controller);
            controller.Push(this);
        }
    }

    partial class Connection : IParentNode
    {
        public int Index { get; set; } = 0;

        public IChildNode[]? ChildNodes => GetInteractables();

        public Action<Controller>? WhenEnter { get; protected set; }
        public Action<Controller>? WhenExit { get; protected set; }
    }
}
