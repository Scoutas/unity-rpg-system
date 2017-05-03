using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Module.Factory;


using System;

namespace Module.ItemTypes
{
    public class ItemTypeEditor : EditorWindow
    {

        ItemTypeDatabase itemTypeDatabase;
        

        public ItemTypeEditor()
        {
            itemTypeDatabase = new ItemTypeDatabase(new ItemTypeFactory());
        }

        public void Display()
        {
            
        }
    }


}