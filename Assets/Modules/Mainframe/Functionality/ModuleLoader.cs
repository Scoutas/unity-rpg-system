﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using RPSystem;
using UnityEditor;

namespace RPSystem{
	public class ModuleLoader {

		private Mainframe _parent { get; set;}
		private List<MainframeModule> _modules { get; set; }

		public List<MainframeModule> Modules{ get { return _modules; } }
		public int Count { get { return _modules.Count; } }
		public MainframeModule GetModuleAtIndex(int index){ return _modules [index]; }

		public ModuleLoader(Mainframe parent){
			_parent = parent;
			_modules = new List<MainframeModule>();
			LoadModules ();
		}
			
		void LoadModules(){
			foreach (System.Type moduleType in TypeReflection.FindDerivedTypes<MainframeModule>()) {
				var instance = TypeReflection.Initialize<MainframeModule> (moduleType);
				instance.SetMainframe (_parent);
				_modules.Add (instance);
			}
		}


	}


}
