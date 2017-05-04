using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Module.Display.Information;

public class InformationDisplayModuleFactory {

    public MainDisplay BuildMainInformationDisplay(Module.Information parent)
    {
        MainDisplay newMainDisplay = new MainDisplay(parent);
        newMainDisplay.SetUpOtherDisplays(
            BuildModuleDisplay(newMainDisplay),
            BuildModuleInformationDisplay(newMainDisplay));
        return newMainDisplay;
    }

    ModuleDisplay BuildModuleDisplay(MainDisplay parent)
    {
        return new ModuleDisplay(parent);
    }

    InformationDisplay BuildModuleInformationDisplay(MainDisplay parent)
    {
        return new InformationDisplay(parent);
    }
}
