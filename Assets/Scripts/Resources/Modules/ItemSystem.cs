using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Module{
	
	public class ItemSystem : Editor.Module {

		public override string Name {
			get {
				return "Item System";
			}
		}

		public override string Version {
			get {
				return "0.0.01";
			}
		}

	
		public override void Main ()
		{
			EditorGUILayout.LabelField ("This is an " + Name + " module!", EditorStyles.boldLabel);
		}




		
	}
}
