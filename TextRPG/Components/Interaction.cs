using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Static;

namespace TextRPG.Components
{
    public abstract partial class Interaction : Component
    {
        protected Interaction(string objectID) : base(objectID)
        {
            PassCheckFunc = (controller) => true;

            ShowInformation = Information;
            ShowPreview = Preview;
            SelectThis = Select;
        }

        public virtual void Information(Controller controller)
        {
            controller.PrintLine(Get(Text.Information));
        }
        public abstract void Preview(Controller controller);
        public abstract void Select(Controller controller);
    }

    partial class Interaction : IChildNode
    {
        //public string Label
        //{
        //    get => Get(Text.Label);
        //    set => Set(Text.Label, value);
        //}
        public string Label => Text.GetKR(GetType().Name);

        public Func<Controller, bool> PassCheckFunc { get; protected set; }

        public Action<Controller>? ShowInformation { get; protected set; }
        public Action<Controller>? ShowPreview { get; protected set; }
        public Action<Controller>? SelectThis { get; protected set; }
    }
}
