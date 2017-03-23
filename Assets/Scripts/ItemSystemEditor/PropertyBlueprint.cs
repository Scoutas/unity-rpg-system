using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ItemSystemEditor {
	[System.Serializable]
	public class PropertyBlueprint {

		// FIXME: 	A question rose. Does the property itself should hold onto
		// 			the booleans that describe it.
		//			e.g. A bool that decides if the property has strings or not.

		// This has been resolved. This should only hold booleans and integers, for the
		// blueprint of the property.

		// It shouldn't be too difficult to actually implement this.
		// Basically, the property editor would just do everything in sequence? 
		// BUt DAMN what if someone wants to rearrange their shizz?

		// EASY IMPLEMENTATION: DO NOT ALLOW USERS TO REARANGE THE ATTRIBUTES OF A PROPERTY.
		// DIFFICULT IMPLEMENTATION: FIGURE OUT A WAY TO DO SO. (Dictionaries, or 2 arrays of strings
		// could work. One, with the same ID would describe the name of the property, and the second one
		// with the same ID could describe the property type.

		// Should these be public?

		// NAME
		[SerializeField] public string propertyName;

//		// BOOLEANS
//		[SerializeField] public bool hasStrings;
//		[SerializeField] public bool hasIntegers;
//
//		// COUNTS
//		[SerializeField] public int stringCount;
//		[SerializeField] public int integerCount;
		// ARRAYS
		[SerializeField] public List<Attribute> attributes;



	}
}
[System.Serializable]
public class Attribute {

	[SerializeField] public int ID;
	[SerializeField] public string Name;
	// TODO: Maybe change it to an actual type? Figure out how to implement that shizz.
	[SerializeField] public string Type;

}

