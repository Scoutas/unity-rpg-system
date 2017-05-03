using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using RPSystem;

namespace Module.Display.Information
{
    public class ModuleDisplay: DisplayModule
    {
        List<MainframeModule> m_loadedModules;
        InformationDisplay m_informationDisplay;

        public ModuleDisplay(List<MainframeModule> loadedModules, InformationDisplay informationDisplay)
        {
            m_loadedModules = loadedModules;
            m_informationDisplay = informationDisplay;
        }

        public override void Display()
        {
            for (int i = 0; i < m_loadedModules.Count; i++)
            {
                DisplayModule(m_loadedModules[i]);
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
            m_informationDisplay.RecieveText(information);
        }
    }
}