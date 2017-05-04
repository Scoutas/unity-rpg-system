using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RPSystem;
using System;

namespace Module.Display.Mainframe {

    public class MainframeDisplay : DisplayModule<RPSystem.Mainframe> {

        RPSystem.Mainframe m_parent;

        public override RPSystem.Mainframe Parent { get { return m_parent; } }

        public MainframeDisplay(RPSystem.Mainframe parent)
        {
            m_parent = parent;
        }

        MainframeModule m_currentActiveModule = null;

        public override void Display()
        {
            EditorGUILayout.BeginHorizontal();

            foreach (MainframeModule module in m_parent.Modules)
            {
                EditorGUI.BeginDisabledGroup(module == m_currentActiveModule);
                DisplayButton(module.Name, LoadUpModule, module);
                EditorGUI.EndDisabledGroup();
            }

            EditorGUILayout.EndHorizontal();

            if(m_currentActiveModule != null)
            {
                m_currentActiveModule.Main();
            }
        }

        void LoadUpModule(MainframeModule module)
        {
            m_currentActiveModule = module;
        }

        void DisplayButton(string text, Action<MainframeModule> function, MainframeModule module)
        {
            if (GUILayout.Button(text))
            {
                function(module);
            }
        }

    }
		
}
