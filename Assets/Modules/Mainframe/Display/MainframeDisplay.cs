﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RPSystem;
using System;

namespace Module.Display.Mainframe{
	
	public class MainframeDisplay: DisplayModule {

        RPSystem.Mainframe m_parent;
        List<MainframeModule> m_modules;

        MainframeModule m_currentActiveModule = null;

        public MainframeDisplay(RPSystem.Mainframe parent, List<MainframeModule> loadedModules)
        {
            m_parent = parent;
            m_modules = loadedModules;
        }

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