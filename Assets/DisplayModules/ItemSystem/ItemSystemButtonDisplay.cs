using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSystem;
using Module.Submodule;
using System;
using UnityEditor;


namespace Module.Display.ItemSystem
{
    public class ItemSystemButtonDisplay : DisplayModule<ItemSystemDisplay>
    {

        ItemSystemDisplay m_parent;
        public override ItemSystemDisplay Parent { get { return m_parent; } }
        List<ItemSystemSubModule> m_subModules;

        public ItemSystemButtonDisplay(ItemSystemDisplay parent)
        {
            m_parent = parent;
        }

        public override void Display()
        {
            EditorGUILayout.BeginHorizontal("Box");
            foreach(ItemSystemSubModule submodule in m_subModules)
            {
                //EditorGUI.BeginDisabledGroup(submodule == m_parent.m_itemSystemDisplay.m_currentlyActiveSubModule);
                //DisplayButton(submodule.Name, SetActiveSubModule, submodule);
                //EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndHorizontal();
        }

        void SetActiveSubModule(ItemSystemSubModule subModule)
        {
            //m_parent.m_itemSystemDisplay.m_currentlyActiveSubModule = subModule;
        }

        void DisplayButton(string text, Action<ItemSystemSubModule> function, ItemSystemSubModule submodule )
        {
            if (GUILayout.Button(text))
            {
                function(submodule);
            }
        }

    }
}
