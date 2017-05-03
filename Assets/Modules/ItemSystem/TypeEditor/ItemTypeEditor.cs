using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Module.Factory;
using Module.Submodule;


using System;

namespace Module.ItemTypes
{
    public class ItemTypeEditor : ItemSystemSubModule
    {

        public override string Name { get { return "Item Type Editor"; } }

        ItemTypeDatabase itemTypeDatabase;
        

        public ItemTypeEditor()
        {
            itemTypeDatabase = new ItemTypeDatabase(new ItemTypeFactory());
        }

        public override void Main()
        {
            EditorGUILayout.BeginVertical("Box");
            foreach (ItemType itemType in itemTypeDatabase.m_itemTypeList)
            {
                string full = itemType.Name + " :: Child types: ";
                foreach(ItemType childType in itemType.Children)
                {
                    full += childType.Name + " | ";
                }
                EditorGUILayout.LabelField(full);
            }
            EditorGUILayout.EndVertical();
        }

        


    }


}