using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RPSystem;
using Module.Display.Information;
using Module.Factory;

namespace Module{
	
	public class Information : MainframeModule {

		// TODO: Add settings, to each module here?
		// e.g. You're in the Information module and you do the cool checks
		// 		you would actually have an option of choosing to open options
		//		where you could configure different things inside the modules
		//		like the names of the databases and etc.

		#region Information

		public override string Name {
			get {
				return "Information";
			}
		}

		public override string CurrentVersion {
			get {
				return "0.1.01";
			}
		}

		public override string VersionHistory {
			get {
				return
                    "Information Module :: Version 0.1.01 \n" +
                        " + Updated the module to use DisplayModule modules for display.\n\n" +
                    "Information Module :: Version 0.0.04 \n" +
						" + Refactoring \n\n" +
					"Information Module :: Version 0.0.03 \n" +
						" + Added a scroll bar for the text. \n\n" +
					"Information Module :: Version 0.0.02 \n" +
						" + Added 'Information' \n\n" +
					"Information Module :: Version 0.0.01 \n" +
						" + Added 'Version History' \n" +
						" + Initial setup";
			}
		}

		public override string Description {
			get {
				return "This is the information module. It should hold different sorts of information " +
					"about the modules that are loaded. For example, reason and usage of it.";
					
			}
		}

        #endregion

        MainDisplay m_mainDisplay;
        InformationDisplayModuleFactory m_factory;

        public Information()
        {
            if (m_factory == null) { m_factory = new InformationDisplayModuleFactory(); }
            if (m_mainDisplay == null) { m_mainDisplay = m_factory.BuildMainInformationDisplay(this); }
        }
        
 
		public override void Main ()
		{
            m_mainDisplay.Display();
		}

        void OnEnable()
        {
            
        }
	}	
}
