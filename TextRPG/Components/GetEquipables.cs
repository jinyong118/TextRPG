using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Static;

namespace TextRPG.Components
{
    public abstract class GetEquipables : Connection
    {
        protected GetEquipables(string objectID) : base(objectID)
        {
        }

        public override void Information(Controller controller)
        {
            controller.PrintLine("착용 중인 장비의 성능");
        }
    }

    public class GetArmors : GetEquipables
    {
        public GetArmors(string objectID) : base(objectID)
        {
        }

        protected override IChildNode[]? GetInteractables()
        {
            if (gameObject == null)
            {
                UI.SystemMessage($"\"{gameObjectID}\" GameObject not exist.");
                return null;
            }
            var list = from obj in gameObject.LinkedObjects
                       where obj.IsContain<Armor>()
                       select obj.GetComponent<Armor>();
            return list.ToArray();
        }
    }

    public class GetMainWeapons : GetEquipables
    {
        public GetMainWeapons(string objectID) : base(objectID)
        {
        }

        protected override IChildNode[]? GetInteractables()
        {
            if (gameObject == null)
            {
                UI.SystemMessage($"\"{gameObjectID}\" GameObject not exist.");
                return null;
            }
            var list = from obj in gameObject.LinkedObjects
                       where obj.IsContain<MainWeapon>()
                       select obj.GetComponent<MainWeapon>();
            return list.ToArray();
        }
    }

    public class GetSubWeapons : GetEquipables
    {
        public GetSubWeapons(string objectID) : base(objectID)
        {
        }

        protected override IChildNode[]? GetInteractables()
        {
            if (gameObject == null)
            {
                UI.SystemMessage($"\"{gameObjectID}\" GameObject not exist.");
                return null;
            }
            var list = from obj in gameObject.LinkedObjects
                       where obj.IsContain<SubWeapon>()
                       select obj.GetComponent<SubWeapon>();
            return list.ToArray();
        }
    }

    public class GetAccessories : GetEquipables
    {
        public GetAccessories(string objectID) : base(objectID)
        {
        }

        protected override IChildNode[]? GetInteractables()
        {
            if (gameObject == null)
            {
                UI.SystemMessage($"\"{gameObjectID}\" GameObject not exist.");
                return null;
            }
            var list = from obj in gameObject.LinkedObjects
                       where obj.IsContain<Accessory>()
                       select obj.GetComponent<Accessory>();
            return list.ToArray();
        }
    }
}
