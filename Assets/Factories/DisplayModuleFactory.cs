using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSystem;
using Module.Display.Information;
using Module.Display.Mainframe;

namespace Module.Factory
{
    public static class DisplayModuleFactory
    {

        public static MainDisplay BuildMainInformationDisplay(ModuleDisplay moduleDisplay, InformationDisplay informationDisplay)
        {
            return new MainDisplay(moduleDisplay, informationDisplay);
        }

        public static ModuleDisplay BuildModuleDisplay(List<MainframeModule> loadedModules, InformationDisplay informationDisplay)
        {
            return new ModuleDisplay(loadedModules, informationDisplay);
        }

        public static InformationDisplay BuildModuleInformationDisplay()
        {
            return new InformationDisplay();
        }

        public static MainframeDisplay BuildMainframeDisplay(Mainframe parent, List<MainframeModule> loadedModules)
        {
            return new MainframeDisplay(parent, loadedModules);
        }


    }
}