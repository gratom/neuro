using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Organisms.Sworm
{
    using Global.Component.Genetic;

    public class Sworm : BaseGenable
    {
        public override float Value => transform.position.x;
    }
}