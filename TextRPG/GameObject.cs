using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Components;
using TextRPG.Static;

namespace TextRPG
{
    public partial class GameObject
    {
        public string ID
        {
            get => Get("ID");
            set => Set("ID", value);
        }
        public string Name
        {
            get => Get("Name");
            set => Set("Name", value);
        }

        private readonly Dictionary<string, string> textData;

        public GameObject[] LinkedObjects => Finds(Gets("LinkedObjects"));
        public Component[] Components => Component.Data[ID].ToArray();

        public GameObject(Dictionary<string, string> data)
        {
            textData = data;

            Data.TryAdd(ID, this);
            MakeComponents();
        }

        public string Get(string label)
        {
            if (textData.ContainsKey(label))
            {
                return textData[label];
            }
            return label;
        }
        public string[] Gets(string label)
        {
            if (textData.ContainsKey(label))
            {
                return textData[label].Split('/');
            }
            return new string[] { label };
        }

        public bool Set(string label, string value)
        {
            if (textData.ContainsKey(label))
            {
                textData[label] = value;
                return true;
            }
            else
            {
                textData.Add(label, value);
                return false;
            }
        }
        public bool Sets(string label, string[] values)
        {
            if (textData.ContainsKey(label))
            {
                textData[label] = DataReader.Combine(values);
                return true;
            }
            return false;
        }

        public T? AddComponent<T>() where T : Component
        {
            if (Activator.CreateInstance(typeof(T), new object[] { ID }) is T instance)
            {
                return instance;
            }
            return null;
        }
        public Component? GetComponent(string name)
        {
            Component[] list = Components;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].GetType().Name == name)
                {
                    return list[i];
                }
            }
            return null;
        }
        public T? GetComponent<T>() where T : Component
        {
            Component[] list = Components;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].GetType().Name == typeof(T).Name)
                {
                    return list[i] as T;
                }
            }
            return null;
        }

        public T[] GetComponents<T>() where T : class, IChildNode
        {
            var arr = from component in Components
                      where component is T
                      select component as T;
            return arr.ToArray();
        }

        public bool IsContain<T>() where T : Component
        {
            for (int i = 0; i < Components.Length; i++)
            {
                if (Components[i].GetType().Name == typeof(T).Name)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsContain(string name)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                if (Components[i].GetType().Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void MakeComponents()
        {
            string[] contents = Gets("Components");
            foreach (string content in contents)
            {
                Component.CreateComponent(content, ID);
            }
        }

        public T[] GetLinkedComponents<T>() where T : Interactable
        {
            var list = from obj in LinkedObjects
                       where obj.IsContain<T>()
                       select obj.GetComponent<T>();
            return list.ToArray();
        }
    }

    partial class GameObject
    {
        public readonly static Dictionary<string, GameObject> Data = new();

        public static GameObject? Find(string id)
        {
            return Data.ContainsKey(id) ? Data[id] : null;
        }
        public static GameObject[] Finds(string[] ids)
        {
            var list = from id in ids
                       where Data.ContainsKey(id)
                       select Data[id];
            return list.ToArray();
        }

        public static bool MakeAllObjects()
        {
            string[] paths = DataReader.GetFilePahts("GameObjects");
            Dictionary<string, string> textData;
            GameObject gameObject;
            foreach (string path in paths)
            {
                textData = DataReader.ReadData(path);
                gameObject = new(textData);
            }
            return false;
        }
        public static bool MakeAllObjects2()
        {
            List<Dictionary<string, string>> data = DataReader.GetData(DataReader.Path + @"/GameObjectData.txt");
            for (int i = 0; i < data.Count; i++)
            {
                _ = new GameObject(data[i]);
            }
            return true;
        }

        static int count = 0;
        public static GameObject Creat(Dictionary<string, string> data)
        {
            data[Text.Label] += "_" + count.ToString();
            return new GameObject(data);
        }
    }
}
