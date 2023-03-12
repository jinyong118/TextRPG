using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Components;
using TextRPG.Static;
using System.Reflection;

namespace TextRPG.Components
{
    public abstract partial class Component
    {
        public string gameObjectID;
        public GameObject? gameObject => GameObject.Find(gameObjectID);

        public Component(string objectID)
        {
            gameObjectID = objectID;
            if (!Data.ContainsKey(objectID))
            {
                Data.Add(objectID, new List<Component>());
            }
            Data[objectID].Add(this);
        }

        public string Get(string label)
        {
            if (gameObject != null)
            {
                return gameObject.Get($"{GetType().Name}.{label}");
            }
            return $"There is not exist label: {label} in ID: {gameObject?.ID}";
        }
        public string[] Gets(string label)
        {
            if (gameObject != null)
            {
                return gameObject.Gets($"{GetType().Name}.{label}");
            }
            return new string[] { $"There is not exist label: {label} in ID: {gameObject?.ID}" };
        }

        public bool Set(string label, string value)
        {
            if (gameObject != null)
            {
                return gameObject.Set($"{GetType().Name}.{label}", value);
            }
            return false;
        }
        public bool Sets(string label, string[] values)
        {
            if (gameObject != null)
            {
                return gameObject.Sets($"{GetType().Name}.{label}", values);
            }
            return false;
        }
    }

    partial class Component
    {
        public readonly static Dictionary<string, List<Component>> Data = new();

        public static Component? CreateComponent(string componentName, string id)
        {
            if (Type.GetType($"TextRPG.Components.{componentName}") is not Type type)
            {
                UI.SystemMessage($"\"{componentName}\" Component not exist.");
                return null;
            }
            if (Activator.CreateInstance(type, id) is not Component component)
            {
                UI.SystemMessage($"\"{type.Name}\" Component could not be created.");
                return null;
            }
            return component;
        }
    }
}
