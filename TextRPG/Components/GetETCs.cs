using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;

namespace TextRPG.Components
{
    public abstract class GetETCs : Connection
    {
        protected GetETCs(string objectID) : base(objectID)
        {
        }
    }

    public class GetQuestOnly : GetETCs
    {
        public GetQuestOnly(string objectID) : base(objectID)
        {
        }

        protected override IChildNode[]? GetInteractables()
        {
            var list = from obj in gameObject.LinkedObjects
                       where obj.IsContain<QuestOnly>()
                       select obj.GetComponent<QuestOnly>();
            return list.ToArray();
        }
    }
}
