using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Components
{
    public abstract class Equipables : Interactable
    {
        protected Equipables(string objectID) : base(objectID)
        {
        }
    }

    public class Armor : Equipables
    {
        public Armor(string objectID) : base(objectID)
        {
        }

        public override void Information(Controller controller)
        {
            controller.PrintLine("장비의 스펙");
        }
    }

    public class MainWeapon : Equipables
    {
        public MainWeapon(string objectID) : base(objectID)
        {
        }
    }

    public class SubWeapon : Equipables
    {
        public SubWeapon(string objectID) : base(objectID)
        {
        }
    }

    public class Accessory : Equipables
    {
        public Accessory(string objectID) : base(objectID)
        {
        }
    }
}
