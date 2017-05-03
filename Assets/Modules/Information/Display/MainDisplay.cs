using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RPSystem;

namespace Module.Display.Information
{

	public class MainDisplay : DisplayModule {

        ModuleDisplay m_moduleDisplay;
        InformationDisplay m_informationDisplay;

        public MainDisplay(ModuleDisplay moduleDisplay, InformationDisplay informationDisplay)
        {
            m_moduleDisplay = moduleDisplay;
            m_informationDisplay = informationDisplay;
        }
        

        public override void Display()
        {

            EditorGUILayout.BeginHorizontal();

            DisplayLoadedModules();
            DisplayCurrentInformation();

            EditorGUILayout.EndHorizontal();

        }

        void DisplayLoadedModules()
        {
            EditorGUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
            m_moduleDisplay.Display();
            EditorGUILayout.EndVertical();
        }

        void DisplayCurrentInformation()
        {
            EditorGUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
            m_informationDisplay.Display();
            EditorGUILayout.EndVertical();
        }

    }
}