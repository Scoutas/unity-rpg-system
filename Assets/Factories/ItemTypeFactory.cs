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

        


    }
}
