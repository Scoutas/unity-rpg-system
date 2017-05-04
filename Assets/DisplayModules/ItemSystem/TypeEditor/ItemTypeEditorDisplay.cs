using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RPSystem;
using Module.Display.ItemSystem;
using Module.Submodule.ItemTypes;

namespace Module.Display.TypeEditor
{
    public class ItemTypeEditorDisplay : DisplayModule<ItemTypeEditorSubmodule>
    {
        ItemTypeEditorSubmodule m_parent;
        public override ItemTypeEditorSubmodule Parent { get { return m_parent; } }

        public ItemTypeEditorDisplay(ItemTypeEditorSubmodule parent) { m_parent = parent; }

        public override void Display()
        {
            foreach(ItemType type in Parent.LoadedItemTypes)
            {
                EditorGUILayout.LabelField(type.Name);
            }
        }



    }
}