using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Genetic
{
    public abstract class BaseGenable : MonoBehaviour
    {
        public abstract float Value { get; }
    }
}