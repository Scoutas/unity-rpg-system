using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RPSystem;
using Module.Display;

namespace Module{
	
	public class Information : MainframeModule {

		// TODO: Add settings, to each module here?
		// e.g. You're in the Information module and you do the cool checks
		// 		you would actually have an option of choosing to open options
		//		where you could configure different things inside the modules
		//		like the names of the databases and etc.

		#region Information

		Vector2 scrollPosition;

		public override string Name {
			get {
				return "Information";
			}
		}

		public override string CurrentVersion {
			get {
				return "0.0.04";
			}
		}

		public override string VersionHistory {
			get {
				return
					
					"Information Module :: Version 0.0.04 \n" +
						" + Refactoring \n\n" +
					"Information Module :: Version 0.0.03 \n" +
						" + Added a scroll bar for the text. \n\n" +
					"Information Module :: Version 0.0.02 \n" +
						" + Added 'Information' \n\n" +
					"Information Module :: Version 0.0.01 \n" +
						" + Added 'Version History' \n" +
						" + Initial setup";
			}
		}

		public override string Description {
			get {
				return "This is the information module. It should hold different sorts of information " +
					"about the modules that are loaded. For example, reason and usage of it.";
					
			}
		}

		#endregion

		BaseDisplay currentDisplay;
	
		public override void Main ()
		{	
			EditorGUILayout.BeginHorizontal ();

			EditorGUILayout.BeginVertical ("Box", GUILayout.Width(400), GUILayout.ExpandHeight(true));

			EditorGUILayout.LabelField ("Currently loaded modules: ", EditorStyles.boldLabel);

			DisplayButtonsHorizontal ();

			EditorGUILayout.EndVertical ();

			DisplayTextBox ();

			EditorGUILayout.EndHorizontal ();

		}

		void DisplayTextBox(){
			EditorGUILayout.BeginVertical ("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			if (currentDisplay != null) {
				currentDisplay.Display ();
			}
			EditorGUILayout.EndVertical ();
		}
			

		void DisplayButtonsHorizontal(){
			foreach (MainframeModule module in base.Mainframe.Loader.Modules) {
				EditorGUILayout.BeginHorizontal (GUILayout.ExpandWidth(false));
				EditorGUILayout.LabelField (module.Name + " :: Version " + module.CurrentVersion);

				if (GUILayout.Button ("Information")) {

					currentDisplay = new BaseDisplay(module.Description);
				}
				if (GUILayout.Button ("Version History")) {

					currentDisplay = new BaseDisplay (module.VersionHistory);
				}

				EditorGUILayout.EndHorizontal ();
			}
		}

	}
		
}
