using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Module.ItemType;

using System;
using System.IO;
using Module.Display;


namespace Module{

	

	public class ItemSystem : RPSystem.MainframeModule {

		#region Information
		
		public override string Name {
			get {
				return "Item System";
			}
		}

		public override string CurrentVersion {
			get {
				return "0.0.00";
			}
		}

		public override string VersionHistory {
			get {
				return 
					"ItemSystem Module :: Version 0.0.01 \n" +
					" + Added 'Version History' \n" +
					" + Initial setup";
			}
		}


        #endregion

        
        ItemTypeEditor itemTypeEditor;
        
        
        string currentNewText = "";


        public ItemSystem(){
			Debug.Log (Name + " module :: Reflection construction");
            
            itemTypeEditor = new ItemTypeEditor();
            
		}

        public override void Main()
        {
            itemTypeEditor.Display();
        }


    }
	
}




