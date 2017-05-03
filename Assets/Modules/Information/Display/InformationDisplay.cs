using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RPSystem;

namespace Module.Display.Information
{
    public class InformationDisplay : DisplayModule
    {

        string m_displayText;

        public override void Display()
        {
            if(m_displayText != null)
            {
                EditorGUILayout.LabelField(m_displayText);
            }
        }

        public void RecieveText(string text)
        {
            m_displayText = text;
        }
    }
}