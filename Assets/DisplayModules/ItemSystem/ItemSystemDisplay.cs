using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSystem;

using Module.Submodule;
using UnityEditor;


namespace Module.Display.ItemSystem
{
    public class ItemSystemDisplay : DisplayModule<Module.ItemSystem>
    {

        Module.ItemSystem m_parent;
        public override Module.ItemSystem Parent { get { return m_parent; } }
        List<ItemSystemSubModule> m_subModules;
        

        ItemSystemButtonDisplay m_itemSystemButtonDisplay;

        //TODO: Change the parentage 
        // either set it up after doing everything 
        // or call it from this constructor, call the factories and all  that.

        public ItemSystemDisplay(Module.ItemSystem parent)
        {
            m_parent = parent;
            
        }

        public void SetUpDisplays(ItemSystemButtonDisplay itemSystemButtonDisplay)
        {
            m_itemSystemButtonDisplay = itemSystemButtonDisplay;
        }

        public ItemSystemSubModule m_currentlyActiveSubModule;

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