using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPSystem
{
    public class DisplayModule<T>
    {

        public virtual T Parent
        {
            get
            {
                throw new NotImplementedException("You haven't overriden the getter of Parent");
            }
        }
        
        public virtual void Display()
        {
            throw new NotImplementedException("You haven't overriden the Display method in a DisplayModule");
        }

    }
}