using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Module.Submodule
{
    public class ItemSystemSubModule
    {

        public virtual string Name { get
            {
                throw new NotImplementedException("You have not overriden the Name of a submodule.");
            }
        }

        public virtual void Main()
        {
            throw new NotImplementedException("You have not overriden the Main method of a submodule.");
        }

    }
}