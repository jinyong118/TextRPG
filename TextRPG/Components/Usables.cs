using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Components
{
    public abstract class Usables : Interactable
    {
        protected Usables(string objectID) : base(objectID)
        {
        }
    }

    public class Drink : Usables
    {
        public Drink(string objectID) : base(objectID)
        {
        }
    }

    public class Scroll : Usables
    {
        public Scroll(string objectID) : base(objectID)
        {
        }
    }

    public class Ingredient : Usables
    {
        public Ingredient(string objectID) : base(objectID)
        {
        }
    }
}
