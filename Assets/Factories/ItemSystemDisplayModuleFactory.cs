using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Module.Display.ItemSystem;
using Module.Display.TypeEditor;
using Module.Submodule.ItemTypes;

namespace Module.Factory.Display
{
    public class ItemSystemDisplayModuleFactory
    {


        ItemSystemButtonDisplay BuildItemSystemButtonDisplay(ItemSystemDisplay parent)
        {
            return new ItemSystemButtonDisplay(parent);
        }

        public ItemSystemDisplay BuildItemSystemDisplay(Module.ItemSystem parent)
        {
            ItemSystemDisplay newDisplay = new ItemSystemDisplay(parent);
            newDisplay.SetUpDisplays(new ItemSystemButtonDisplay(newDisplay));

            return newDisplay;
        }

        public ItemTypeEditorDisplay BuildTypeEditorDisplay(ItemTypeEditorSubmodule parent)
        {
            return new ItemTypeEditorDisplay(parent);
        }


    }
}