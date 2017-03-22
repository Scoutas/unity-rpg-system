using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Module{
	
	public class Information : Editor.Module {

		public override string Name {
			get {
				return "Information";
			}
		}

		public override string Version {
			get {
				return "0.0.01";
			}
		}

	
		public override void Main ()
		{
			EditorGUILayout.LabelField ("Currently installed modules: ", EditorStyles.boldLabel);
			foreach(Editor.Module module in base.Mainframe.loadedModules){
				EditorGUILayout.LabelField (module.Name + " version " +  module.Version);
			}

		}




		
	}
}
