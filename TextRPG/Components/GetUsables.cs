using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;

namespace TextRPG.Components
{
    public abstract class GetUsables : Connection
    {
        protected GetUsables(string objectID) : base(objectID)
        {
        }
    }

    public class GetDrinks : GetUsables
    {
        public GetDrinks(string objectID) : base(objectID)
        {
        }

        protected override IChildNode[]? GetInteractables()
        {
            var list = from obj in gameObject.LinkedObjects
                       where obj.IsContain<Drink>()
                       select obj.GetComponent<Drink>();
            return list.ToArray();
        }
    }

    public class GetScrolls : GetUsables
    {
        public GetScrolls(string objectID) : base(objectID)
        {
        }

        protected override IChildNode[]? GetInteractables()
        {
            var list = from obj in gameObject.LinkedObjects
                       where obj.IsContain<Scroll>()
                       select obj.GetComponent<Scroll>();
            return list.ToArray();
        }
    }

    public class GetIngredients : GetUsables
    {
        public GetIngredients(string objectID) : base(objectID)
        {
        }

        protected override IChildNode[]? GetInteractables()
        {
            var list = from obj in gameObject.LinkedObjects
                       where obj.IsContain<Ingredient>()
                       select obj.GetComponent<Ingredient>();
            return list.ToArray();
        }
    }
}
