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
        float moduleDisplayWidth = 400f;

        public MainDisplay(ModuleDisplay moduleDisplay, InformationDisplay informationDisplay)
        {
            m_moduleDisplay = moduleDisplay;
            m_informationDisplay = informationDisplay;
        }
        

        public override void Display()
        {
            EditorGUILayout.LabelField("Loaded Modules:", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();

            DisplayLoadedModules();
            DisplayCurrentInformation();

            EditorGUILayout.EndHorizontal();

        }

        void DisplayLoadedModules()
        {
            EditorGUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(false), GUILayout.Width(moduleDisplayWidth));
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