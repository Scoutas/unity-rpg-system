using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database{
	[System.Serializable]
	public class PropertyBlueprint : ScriptableObject {

		[SerializeField]public List<ItemSystemEditor.PropertyBlueprint> propertyBlueprintList;

	}
}
