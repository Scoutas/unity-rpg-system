using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPSystem
{
    public class DisplayModule
    {

        public virtual void Display()
        {
            throw new NotImplementedException("You haven't overriden the Display method in a DisplayModule");
        }

    }
}