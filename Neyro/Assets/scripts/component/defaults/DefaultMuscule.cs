using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Defaults
{
    using Global.Component.Perceptron;

    public class DefaultMuscule : Muscule
    {
#pragma warning disable
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private float multiplicator;
#pragma warning restore

        public override void Make(float value)
        {
            rigidbody.AddRelativeTorque(new Vector3(value * multiplicator, 0, 0));
        }
    }
}