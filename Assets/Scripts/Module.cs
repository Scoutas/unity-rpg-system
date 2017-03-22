using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Editor{
	public class Module {

		public MainFrame Mainframe { get; private set;}

		public virtual string Name 			 {get;}
		public virtual string Description 	 {get;}
		public virtual string CurrentVersion {get;}
		public virtual string VersionHistory {get;}

		public virtual void Main()
		{
			
		}
			

		public bool SetMainframe(MainFrame mainframe){
			if (Mainframe != null) {
				Debug.LogError ("Mainframe parent of module " + Name + " has already been set. Could you possibly have several copies of a module?");
				return false;
			}
			Mainframe = mainframe;
			return true;
		}
			
	}
}
