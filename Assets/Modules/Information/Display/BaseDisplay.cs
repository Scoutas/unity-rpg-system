using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RPSystem;
namespace Module.Display{

	public class BaseDisplay {
		
		string displayText = "";
		Vector2 scrollPosition = Vector2.zero;


		public BaseDisplay(string textToDisplay){
			EditorStyles.label.wordWrap = true;
			displayText = textToDisplay;
		}

	
		public void Display(){

			using (var scrollViewText = new GUILayout.ScrollViewScope (scrollPosition)) {
				scrollPosition = scrollViewText.scrollPosition;
				EditorGUILayout.LabelField (displayText, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
			}
		}



	}
}