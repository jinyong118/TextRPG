using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;

namespace TextRPG.Menu
{
    public partial class Setting
    {
        public static readonly Setting one = new();

        private Setting()
        {
            Label = nameof(Setting);
            PassCheckFunc = (controller) => true;
            ShowInformation = (controller) => controller.PrintLine("Setting");
            ShowPreview = null;
            SelectThis = (controller) => controller.NotYet();
        }
    }

    partial class Setting : IChildNode
    {
        public string Label { get; protected set; }

        public Func<Controller, bool> PassCheckFunc { get; protected set; }

        public Action<Controller>? ShowPreview { get; protected set; }
        public Action<Controller>? ShowInformation { get; protected set; }
        public Action<Controller>? SelectThis { get; protected set; }
    }
}
