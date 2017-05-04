using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RPSystem;

namespace Module.Display.Information
{

	public class MainDisplay : DisplayModule<Module.Information> {

        Module.Information m_parent;
        ModuleDisplay m_moduleDisplay;
        InformationDisplay m_informationDisplay;

        public override Module.Information Parent { get { return m_parent; } }
        public ModuleDisplay Display_Modules { get { return m_moduleDisplay; } }
        public InformationDisplay Display_Information { get { return m_informationDisplay; } }


        float moduleDisplayWidth = 400f;

        public MainDisplay(Module.Information parent)
        {
            m_parent = parent;
        }

        public void SetUpOtherDisplays(ModuleDisplay moduleDisplay, InformationDisplay informationDisplay)
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