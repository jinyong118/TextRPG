using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Components
{
    public enum ItemClassify
    {
        Drinkable = 1,
        Equipment = 2,
        ETC = 4,
        Potion = 9,
        Scroll = 17,
        Ingredient = 33,
        Body = 66,
        Main = 130,
        Sub = 258,
        Accessory = 514,
        Quest = 1028
    }

    public class Inventoriable : Interactable
    {
        public Inventoriable(string objectID) : base(objectID)
        {
        }
    }
}
