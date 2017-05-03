using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSystem;
using Module.Submodule;
using UnityEditor;

namespace Module.Display.ItemSystem
{
    public class ItemSystemDisplay : DisplayModule
    {
        List<ItemSystemSubModule> m_subModules;
        public ItemSystemSubModule m_currentlyActiveSubModule;
        ItemSystemButtonDisplay m_itemSystemButtonDisplay;

        //TODO: Change the parentage 
        // either set it up after doing everything 
        // or call it from this constructor, call the factories and all  that.

        public ItemSystemDisplay(ItemSystemButtonDisplay itemSystemButtonDisplay)
        {
            m_itemSystemButtonDisplay = itemSystemButtonDisplay;
        }

        public override void Display()
        {
            m_itemSystemButtonDisplay.Display();
            if(m_currentlyActiveSubModule != null)
            {
                m_currentlyActiveSubModule.Main();
            }
        }

    }
}