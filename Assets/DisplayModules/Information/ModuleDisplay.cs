using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using RPSystem;

namespace Module.Display.Information
{
    public class ModuleDisplay: DisplayModule<MainDisplay>
    {

        MainDisplay m_parent;
        public override MainDisplay Parent { get { return m_parent; } }


        public ModuleDisplay(MainDisplay parent)
        {
            m_parent = parent;
        }

        public override void Display()
        {
            for (int i = 0; i < ModuleCount; i++)
            {
                DisplayModule(GetModuleByIndex(i));
            }
        }

        void DisplayModule(MainframeModule module)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(string.Format("{0} :: Version {1}", module.Name, module.CurrentVersion), GUILayout.MaxWidth(200f));
            DisplayButton("Information",    SendInformation,    module.Description);
            DisplayButton("VersionHistory", SendInformation,    module.VersionHistory);
            EditorGUILayout.EndHorizontal();
        }

        void DisplayButton(string text, Action<string> function, string information)
        {
            if (GUILayout.Button(text))
            {
                function(information);
            }
        }

        void SendInformation(string information)
        {
            Parent.Display_Information.RecieveText(information);
        }

        int ModuleCount
        {
           get { return Parent.Parent.MainframeInstance.Modules.Count; }
        }

        MainframeModule GetModuleByIndex(int index)
        {
            return Parent.Parent.MainframeInstance.Modules[index];
        }
    }
}