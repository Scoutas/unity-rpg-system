using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Module.Submodule.ItemTypes;

namespace Module.Factory.ItemSystem
{
    public class ItemTypeFactory
    {


        public ItemType CreateNewType(string name)
        {
            ItemType newType = new ItemType() { Name = name };
            return newType;
        }

        public ItemType CreateNewType(string name, List<ItemType> children)
        {
            ItemType newType = new ItemType() { Name = name, Children = children };
            return newType;
        }

        


    }
}
