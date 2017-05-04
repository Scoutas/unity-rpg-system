using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RPSystem;

namespace Module.Display.Information
{
    public class InformationDisplay : DisplayModule<MainDisplay>
    {
        MainDisplay m_parent;

        public override MainDisplay Parent { get { return m_parent; } }

        public InformationDisplay(MainDisplay parent)
        {
            m_parent = parent;
        }

        string m_displayText;

        public override void Display()
        {
            
            if(m_displayText != null)
            {
                EditorGUILayout.LabelField(m_displayText, EditorStyles.wordWrappedLabel);
            }
        }

        public void RecieveText(string text)
        {
            m_displayText = text;
        }
    }
}