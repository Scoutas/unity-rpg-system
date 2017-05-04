using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Module.Factory.ItemSystem;
using Module.Submodule;
using Module.Display.TypeEditor;
using Module.Factory.Display;

using System;

namespace Module.Submodule.ItemTypes
{
    public class ItemTypeEditorSubmodule : ItemSystemSubModule
    {


        public override string Name { get { return "Item Type Editor"; } }
        public override ItemSystem Parent { get { return m_parent; } }

        ItemTypeDatabase m_itemTypeDatabase;
        ItemSystemDisplayModuleFactory m_factory;
        ItemTypeEditorDisplay m_itemTypeEditorDisplay;
        ItemSystem m_parent;

        public List<ItemType> LoadedItemTypes { get { return m_itemTypeDatabase.LoadedItemTypes; } }


        public ItemTypeEditorSubmodule(ItemSystem parent, ItemSystemDisplayModuleFactory factory)
        {
            if(m_parent == null) { m_parent = parent; }
            if (m_itemTypeDatabase == null) { m_itemTypeDatabase = new ItemTypeDatabase(new ItemTypeFactory()); }
            if (m_factory == null) { m_factory = factory; }
            if (m_itemTypeEditorDisplay == null) { m_itemTypeEditorDisplay = m_factory.BuildTypeEditorDisplay(this); }

        }

        public override void Main()
        {
            m_itemTypeEditorDisplay.Display();
        }

    }

}