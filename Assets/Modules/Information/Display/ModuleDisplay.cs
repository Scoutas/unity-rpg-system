using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RPSystem;

namespace Module.Display.Information
{
    public class ModuleDisplay: DisplayModule
    {
        List<MainframeModule> m_loadedModules;

        public ModuleDisplay(List<MainframeModule> loadedModules)
        {
            m_loadedModules = loadedModules;
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
            EditorGUILayout.LabelField(string.Format("{0} :: Version {1}", module.Name, module.CurrentVersion));
        }

    }
}