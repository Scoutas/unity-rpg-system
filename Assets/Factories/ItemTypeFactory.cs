using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Module.ItemTypes;

namespace Module.Factory
{
    public class ItemTypeFactory
    {


        public ItemType CreateNewType(string name)
        {
            ItemType newType = new ItemType();
            newType.Name = name;
            return newType;
        }

        public ItemType CreateNewType(string name, List<ItemType> children)
        {
            ItemType newType = new ItemType();
            newType.Name = name;
            newType.Children = children;
            return newType;
        }

        public void AddChildToType(ItemType type, ItemType child)
        {
            if (type.Children.Contains(child))
            {
                string warningMessage = string.Format("The type {0} is already a child of type {1}.", child, type);
                Debug.LogWarning(warningMessage);
                return;
            }

            type.Children.Add(child);
        }


    }
}
