using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSystem;

namespace Module.Factory
{
    public class DisplayModuleFactory
    {

        public DisplayModule BuildMainInformationDisplay(DisplayModule moduleDisplay, DisplayModule informationDisplay )
        {
            return new Display.Information.MainDisplay(moduleDisplay, informationDisplay);
        }

        public DisplayModule BuildModuleDisplay(List<MainframeModule> loadedModules)
        {
            return new Display.Information.ModuleDisplay(loadedModules);
        }

        public DisplayModule BuildModuleInformationDisplay()
        {
            return new Display.Information.InformationDisplay();
        }


    }
}