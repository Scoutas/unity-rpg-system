using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Module{
	
	public class ItemSystem : Editor.Module {

		#region Information
		
		public override string Name {
			get {
				return "Item System";
			}
		}

		public override string CurrentVersion {
			get {
				return "0.0.01";
			}
		}

		public override string VersionHistory {
			get {
				return 	"ItemSystem Module :: Version 0.0.01 \n" +
					" + Added 'Version History' \n" +
					" + Initial setup";
			}
		}

			
		#endregion

		public override void Main ()
		{
			EditorGUILayout.LabelField ("This is an " + Name + " module!", EditorStyles.boldLabel);
		}




		
	}
}
