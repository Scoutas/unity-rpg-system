using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSystem;
using Module.Display.Information;
using Module.Display.Mainframe;
using Module.Display.ItemSystem;
using Module.Submodule;

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

        public static MainframeDisplay BuildMainframeDisplay(List<MainframeModule> loadedModules)
        {
            return new MainframeDisplay(loadedModules);
        }

        public static ItemSystemButtonDisplay BuildItemSystemButtonDisplay(ItemSystem parent, List<ItemSystemSubModule> subModules)
        {
            return new ItemSystemButtonDisplay(parent, subModules);
        }

        public static ItemSystemDisplay BuildItemSystemDisplay(ItemSystemButtonDisplay itemSystemButtonDisplay)
        {
            return new ItemSystemDisplay(itemSystemButtonDisplay);
        }


    }
}