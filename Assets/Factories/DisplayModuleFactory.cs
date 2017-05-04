using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSystem;
using Module.Display.Information;
using Module.Display.ItemSystem;
using Module.Submodule;

namespace Module.Factory.Display
{
    public class ItemSystemDisplayFactory
    {

        

        

        public ItemSystemButtonDisplay BuildItemSystemButtonDisplay(ItemSystemDisplay parent)
        {
            return new ItemSystemButtonDisplay(parent);
        }

        public ItemSystemDisplay BuildItemSystemDisplay(ItemSystemButtonDisplay itemSystemButtonDisplay)
        {
            return new ItemSystemDisplay(itemSystemButtonDisplay);
        }


    }
}