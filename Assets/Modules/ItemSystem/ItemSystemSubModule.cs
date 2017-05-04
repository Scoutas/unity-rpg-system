using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Module.Submodule
{

    // TODO: Have a polymorphic solution to a submodule.

    public class ItemSystemSubModule
    {
        public virtual ItemSystem Parent { get { throw new NotImplementedException("You have not overriden the Parent property of a submodule."); } }

        public virtual string Name
        {
            get
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