using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;

namespace TextRPG
{
    public abstract class Controller
    {
        public GameObject? Character { get; private set; }

        protected readonly Stack<IParentNode> nodeStack = new();
        private IParentNode initNode;

        public readonly List<string> PassList = new();

        protected Controller(IParentNode init)
        {
            initNode = init;
        }

        public void SetInitNode(IParentNode init)
        {
            initNode = init;
        }
        public void SetCharacter(GameObject character)
        {
            Character = character;
        }

        public void Push(IParentNode higher)
        {
            nodeStack.Push(higher);
        }
        public IParentNode Pop()
        {
            if (nodeStack.Count == 0)
            {
                AddPass(initNode.GetType().Name);
                return initNode;
            }
            return nodeStack.Pop();
        }

        public abstract void Control();
        public abstract void Cancle(int count = 1);

        public abstract IChildNode? SelectOne(IParentNode higher);
        public abstract bool? MoveArrow(IParentNode higher);

        public abstract void Print(string str);
        public abstract void PrintEnter(string str);
        public abstract void PrintLine(string str);

        public abstract void ReadScripts(string[] script);

        public abstract void Log(string str);

        public abstract void NotYet();

        public void AddPass(string pass)
        {
            if (!PassList.Contains(pass))
            {
                PassList.Add(pass);
            }
        }
        public void RemovePass(string pass)
        {
            PassList.Remove(pass);
        }
    }
}
