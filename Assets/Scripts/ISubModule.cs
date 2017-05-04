using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module.Submodule
{
    public interface ISubModule<T>
    {
        T Parent { get; }

    }
}