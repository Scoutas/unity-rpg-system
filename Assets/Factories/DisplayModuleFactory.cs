using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSystem;
using Module.Display.Information;

namespace Module.Factory
{
    public class DisplayModuleFactory
    {

        public MainDisplay BuildMainInformationDisplay(ModuleDisplay moduleDisplay, InformationDisplay informationDisplay)
        {
            return new MainDisplay(moduleDisplay, informationDisplay);
        }

        public ModuleDisplay BuildModuleDisplay(List<MainframeModule> loadedModules, InformationDisplay informationDisplay)
        {
            return new ModuleDisplay(loadedModules, informationDisplay);
        }

        public InformationDisplay BuildModuleInformationDisplay()
        {
            return new InformationDisplay();
        }


    }
}