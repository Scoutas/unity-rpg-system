using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace RPSystem{
	public class MainframeModule {

		public MainFrame MainframeInstance { get; private set;}

		public virtual string Name
        {
            get
            {
                throw new NotImplementedException("You haven't overriden the Name property in the MainframeModule");
            }
        }
        public virtual string Description
        {
            get
            {
                throw new NotImplementedException("You haven't overriden the Description property in the MainframeModule");
            }
        }
        public virtual string CurrentVersion
        {
            get
            {
                throw new NotImplementedException("You haven't overriden the CurrentVersion property in the MainframeModule");
            }
        }
        public virtual string VersionHistory
        {
            get
            {
                throw new NotImplementedException("You haven't overriden the VersionHistory property in the MainframeModule");
            }
        }


        public virtual void Main()
		{

            throw new NotImplementedException("You haven't overriden the Main method in the MainframeModule");

        }


        public void SetMainframe(MainFrame mainframe){
			if (MainframeInstance != null) {
				Debug.LogWarning ("Mainframe parent of module " + Name + " has already been set. Could you possibly have several copies of a module?");
			}
            MainframeInstance = mainframe;
		}
			
	}
}
