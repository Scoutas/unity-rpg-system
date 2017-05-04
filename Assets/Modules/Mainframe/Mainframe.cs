using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Module.Display.Mainframe;
using Module.Factory.Display;

namespace RPSystem{
	public class Mainframe : EditorWindow {
		
		public static Mainframe m_window;
        MainframeDisplay m_mainframeDisplay;
        MainframeDisplayModuleFactory m_displayFactory;


        ModuleLoader m_loader { get; set; }
        public MainframeModule m_currentActiveModule = null;


        public List<MainframeModule> Modules {
            get {
                if (m_loader == null) { throw new ArgumentNullException("Loader does not exist"); }
                if (m_loader.Modules == null) { throw new ArgumentNullException("Modules List in the Loader does not exist"); }
                return m_loader.Modules;
            }
        }
		
        void OnGUI()
        {
            m_mainframeDisplay.Display();
        }





		[MenuItem("Role Playing System/Editor")]
		static void Initialize(){
            Debug.Log("Mainframe :: Initialization");
            m_window = EditorWindow.GetWindow (typeof(Mainframe)) as Mainframe;
		}

		void OnEnable(){
			
			if (m_loader == null) { m_loader = new ModuleLoader ( this ); }
            if (m_displayFactory == null) { m_displayFactory = new MainframeDisplayModuleFactory(); }
            if (m_mainframeDisplay == null) { m_mainframeDisplay = m_displayFactory.BuildMainframeDisplay(this); }
		}


	}
}
