using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Database{
	[System.Serializable]
	public class PropertyDatabase : ScriptableObject {

		[SerializeField]public List<ItemSystemEditor.Property> propertyList;

	}
}
