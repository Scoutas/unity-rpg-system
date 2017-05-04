using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Module.ItemTypes;

using System;
using System.IO;
using Module.Display.ItemSystem;
using Module.Submodule;
using Module.Submodule.ItemTypes;
using Module.Factory.Display;



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
        ItemSystemDisplayModuleFactory m_factory;
        ItemSystemDisplay m_itemSystemDisplay;

        string currentNewText = "";


        public ItemSystem(){
			Debug.Log (Name + " module :: Reflection construction");
            if(m_factory == null) { m_factory = new ItemSystemDisplayModuleFactory(); }
            if(m_itemSystemDisplay == null) { m_itemSystemDisplay = m_factory.BuildItemSystemDisplay(this); }
            m_subModules = new List<ItemSystemSubModule> {
                new ItemTypeEditorSubmodule(this, m_factory)
            };
        }

        public override void Main()
        {
            m_itemSystemDisplay.Display();
        }

        public List<ItemSystemSubModule> GetSubModules()
        {
            return m_subModules;
        }

        public ItemSystemSubModule GetSubModuleByIndex(int index)
        {
            return m_subModules[index];
        }


    }
	
}




