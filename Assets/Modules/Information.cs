using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Module{
	
	public class Information : Editor.Module {

		#region Information

		public override string Name {
			get {
				return "Information";
			}
		}

		public override string CurrentVersion {
			get {
				return "0.0.02";
			}
		}

		public override string VersionHistory {
			get {
				return
					"Information Module :: Version 0.0.02 \n" +
					" + Added 'Information' \n" +
					"Information Module :: Version 0.0.01 \n" +
						" + Added 'Version History' \n" +
						" + Initial setup";
			}
		}

		public override string Description {
			get {
				return "This is the information module. It should hold different sorts of information \n" +
					"about the modules that are loaded. For example, reason and usage of it.";
					
			}
		}

		#endregion

		Editor.Module selectedModule = null;
		bool information = false;
		bool versionHistory = false;
	
		public override void Main ()
		{	
			EditorGUILayout.BeginHorizontal ();

			EditorGUILayout.BeginVertical ("Box", GUILayout.Width(400), GUILayout.ExpandHeight(true));

			EditorGUILayout.LabelField ("Currently loaded modules: ", EditorStyles.boldLabel);

			foreach (Editor.Module module in base.Mainframe.loadedModules) {
				EditorGUILayout.BeginHorizontal (GUILayout.ExpandWidth(false));
				EditorGUILayout.LabelField (module.Name + " :: Version " + module.CurrentVersion);
				if (GUILayout.Button ("Information")) {
					
					versionHistory = false;
					information = true;
					selectedModule = module;
				}
				if (GUILayout.Button ("Version History")) {
					information = false;
					versionHistory = true;
					selectedModule = module;

				}
				EditorGUILayout.EndHorizontal ();
			}

			EditorGUILayout.EndVertical ();

			EditorGUILayout.BeginVertical ("Box", GUILayout.ExpandHeight (true), GUILayout.ExpandWidth (true));
			if (selectedModule != null) {
				EditorGUI.BeginDisabledGroup (true);
				if (versionHistory) {
					EditorGUILayout.TextArea (selectedModule.VersionHistory);
				}
				else if (information) {
					EditorGUILayout.TextArea (selectedModule.Description);
				}
				EditorGUI.EndDisabledGroup ();

			}
			EditorGUILayout.EndVertical ();

			EditorGUILayout.EndHorizontal ();

		}

		void SelectModule(Editor.Module module){
			selectedModule = module;
		}




		
	}
}
