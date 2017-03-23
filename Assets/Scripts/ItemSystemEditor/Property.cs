using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ItemSystemEditor{
	
	[System.Serializable]
	public class Property {

		[SerializeField]public string propertyName;

		[SerializeField]public List<string> stringValues = new List<string>();
		[SerializeField]public List<int> intValues = new List<int> ();
		
	}
}





