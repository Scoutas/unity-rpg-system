using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPSystem
{
    public class DisplayModule
    {

        // TODO: This requires a interface implementation, for the parent
        // if I want it to work in the way that I imagine it.
        // basically, every module (submodule), has to have a parent
        // which holds most of the data that it requires

        public virtual void Display()
        {
            throw new NotImplementedException("You haven't overriden the Display method in a DisplayModule");
        }

    }
}