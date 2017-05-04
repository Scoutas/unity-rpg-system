using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Module.Factory;
using Module.Submodule;
using Module.Display.TypeEditor;

using System;

namespace Module.ItemTypes
{
    public class ItemTypeEditor : ItemSystemSubModule
    {

        public override string Name { get { return "Item Type Editor"; } }

        ItemTypeDatabase m_itemTypeDatabase;
        ItemTypeEditorDisplay m_itemTypeEditorDisplay;
        

        public ItemTypeEditor()
        {
            //m_itemTypeDatabase = new ItemTypeDatabase(new ItemTypeFactory());
            m_itemTypeEditorDisplay = new ItemTypeEditorDisplay();
        }

        public override void Main()
        {
           
        }

        


    }


}