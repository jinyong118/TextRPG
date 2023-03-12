using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Interface
{
    public interface IChildNode
    {
        string Label { get; }

        Func<Controller, bool> PassCheckFunc { get; }

        Action<Controller>? ShowInformation { get; }
        Action<Controller>? ShowPreview { get; }
        Action<Controller>? SelectThis { get; }
    }
}
