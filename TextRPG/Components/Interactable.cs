using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Static;

namespace TextRPG.Components
{
    public abstract partial class Interactable : Component
    {
        public Interactable(string objectID) : base(objectID)
        {
            WhenEnter += (controller) => controller.AddPass(GetType().Name);
            WhenExit += (controller) => controller.RemovePass(GetType().Name);

            PassCheckFunc = (controller) => true;

            ShowInformation = Information;
            ShowPreview = Preview;
            SelectThis = Select;
        }

        protected virtual IChildNode[]? GetInteractions()
        {
            if (gameObject == null)
            {
                UI.SystemMessage($"\"{gameObjectID}\" GameObject not exist.");
                return null;
            }
            return gameObject.GetComponents<Interaction>();
        }

        public virtual void Information(Controller controller)
        {
            controller.PrintLine(Get("Information"));
        }
        public virtual void Preview(Controller controller)
        {
            UI.ShowList((this as IParentNode).GetLabels(controller));
        }
        public virtual void Select(Controller controller)
        {
            WhenEnter?.Invoke(controller);
            controller.Push(this);
        }
    }

    partial class Interactable : IParentNode
    {
        public int Index { get; set; } = 0;

        public IChildNode[]? ChildNodes => GetInteractions();

        public Action<Controller>? WhenEnter { get; protected set; }
        public Action<Controller>? WhenExit { get; protected set; }
}

    partial class Interactable : IChildNode
    {
        public string Label
        {
            get => Get("Label");
            set => Set("Label", value);
        }

        public Func<Controller, bool> PassCheckFunc { get; protected set; }

        public Action<Controller>? ShowInformation { get; protected set; }
        public Action<Controller>? ShowPreview { get; protected set; }
        public Action<Controller>? SelectThis { get; protected set; }
    }
}
