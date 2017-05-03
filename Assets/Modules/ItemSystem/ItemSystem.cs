using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Module.ItemTypes;

using System;
using System.IO;
using Module.Display.ItemSystem;
using Module.Submodule;
using Module.Factory;



namespace Module{

	

	public class ItemSystem : RPSystem.MainframeModule {

		#region Information
		
		public override string Name { get { return "Item System"; } }

		public override string CurrentVersion { get { return "0.0.00"; } }

		public override string VersionHistory {
			get {
				return 
					"ItemSystem Module :: Version 0.0.01 \n" +
					" + Added 'Version History' \n" +
					" + Initial setup";
			}
		}

        public override string Description
        {
            get
            {
                return
                    "It's the best description in the world. It's true.";
            }
        }


        #endregion



        List<ItemSystemSubModule> m_subModules;
        public ItemSystemDisplay m_itemSystemDisplay;

        string currentNewText = "";


        public ItemSystem(){
			Debug.Log (Name + " module :: Reflection construction");
            if(m_subModules == null) { m_subModules = new List<ItemSystemSubModule>(); }
            m_subModules.Add(new ItemTypeEditor());
            if(m_itemSystemDisplay == null) {
                m_itemSystemDisplay = DisplayModuleFactory.BuildItemSystemDisplay(
                    DisplayModuleFactory.BuildItemSystemButtonDisplay(this, m_subModules)
                    );
            }
            
		}

        public override void Main()
        {
            m_itemSystemDisplay.Display();
        }


    }
	
}




