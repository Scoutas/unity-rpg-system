using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database{
	[System.Serializable]
	public class Property : ScriptableObject {

		[SerializeField]List<ItemSystemEditor.Property> properties;

	}
}
