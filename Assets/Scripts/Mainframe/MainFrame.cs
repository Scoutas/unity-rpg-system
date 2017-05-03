using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Linq;

namespace RPSystem{
	public partial class MainFrame : EditorWindow {
		
		public static MainFrame window;
		public ModuleLoader Loader { get; protected set; }
		MainframeModule currentActiveModule = null;

		// This should display the mainframe options, for now it only displays buttons
		// that are used to switch between different modules. 

		void OnGUI(){
			
			DrawModuleButtons ();
			if (currentActiveModule != null) {
				currentActiveModule.Main ();
			}
		}

 



		[MenuItem("Role Playing System/Editor")]
		static void Initialize(){
			window = EditorWindow.GetWindow (typeof(MainFrame)) as MainFrame;
		}

		void OnEnable(){
			
			if (Loader == null) { Loader = new ModuleLoader ( this ); }
		}


	}
}
