using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RPSystem{
	
	public partial class MainFrame {


		void DrawModuleButtons(){
			EditorGUILayout.BeginHorizontal ();
			foreach (MainframeModule module in Loader.Modules) {
				EditorGUI.BeginDisabledGroup (module == currentActiveModule);
				if (GUILayout.Button (module.Name)) {
					currentActiveModule = module;
				}
				EditorGUI.EndDisabledGroup ();
			}
			EditorGUILayout.EndHorizontal ();
		}

	}
		
}
