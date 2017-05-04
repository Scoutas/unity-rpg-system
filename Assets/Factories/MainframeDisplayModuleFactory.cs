using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSystem;
using Module.Display.Mainframe;

namespace Module.Factory.Display
{
    public class MainframeDisplayModuleFactory
    {
        public MainframeDisplay BuildMainframeDisplay(Mainframe parent)
        {
            return new MainframeDisplay(parent);
        }

    }
}