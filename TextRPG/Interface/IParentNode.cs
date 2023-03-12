using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Interface
{
    public interface IParentNode
    {
        int Index { get; set; }

        IChildNode[]? ChildNodes { get; }
        IChildNode[] NullChecked => ChildNodes ?? Array.Empty<IChildNode>();
        //IChildNode[] ZeroChecked => NullChecked.Length == 0 ? new IChildNode[] { Nothing.One } : NullChecked;

        IChildNode[] GetNodes(Controller controller)
        {
            var children = from child in NullChecked
                         //where lower.PassCheckFunc(controller)
                         select child;
            IChildNode[] nodes = children.ToArray();
            return nodes.Length == 0 ? new IChildNode[] { Components.Nothing.One } : nodes;
        }

        IChildNode GetCurNode(Controller controller)
        {
            IChildNode[] nodes = GetNodes(controller);
            return nodes.Length > Index ? nodes[Index] : nodes[Index = 0];
        }

        string[] GetLabels(Controller controller)
        {
            var labels = from lower in GetNodes(controller)
                         select lower.Label;
            return labels.ToArray();
        }

        Action<Controller>? WhenEnter { get; }
        Action<Controller>? WhenExit { get; }
    }
}
