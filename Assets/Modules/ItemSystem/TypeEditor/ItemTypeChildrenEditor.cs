using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Module.ItemTypes
{
    public class ItemTypeChildrenEditor : EditorWindow
    {

        public static EditorWindow m_window;
        
        public static void Initialize()
        {
            m_window = EditorWindow.GetWindow(typeof(ItemTypeChildrenEditor)) as ItemTypeChildrenEditor;
        }

    }
}