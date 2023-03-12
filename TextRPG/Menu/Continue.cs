using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;

namespace TextRPG.Menu
{
    public partial class Continue
    {
        public static readonly Continue one = new();

        private Continue()
        {
            Label = nameof(Continue);
            PassCheckFunc = (controller) => true;
            ShowInformation = (controller) => controller.PrintLine("Continue game.");
            ShowPreview = null;
            SelectThis = (controller) => controller.NotYet();
        }
    }

    partial class Continue : IChildNode
    {
        public string Label { get; protected set; }

        public Func<Controller, bool> PassCheckFunc { get; protected set; }

        public Action<Controller>? ShowPreview { get; protected set; }
        public Action<Controller>? ShowInformation { get; protected set; }
        public Action<Controller>? SelectThis { get; protected set; }
    }
}
