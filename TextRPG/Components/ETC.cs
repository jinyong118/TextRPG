using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Components
{
    public abstract class ETC : Interactable
    {
        protected ETC(string objectID) : base(objectID)
        {
        }
    }

    public class QuestOnly : ETC
    {
        public QuestOnly(string objectID) : base(objectID)
        {
        }
    }
}
