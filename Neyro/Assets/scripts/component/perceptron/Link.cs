using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Perceptron
{
    public class Link
    {
#pragma warning disable
        [SerializeField] private float _value;
        [SerializeField] private Neuron neuron;
#pragma warning restore

        public float Value
        {
            get
            {
                return _value * Koef;
            }
            private set
            {
                _value = value;
            }
        }

        public float Koef { get; set; }

        #region public functions

        public void RecalculateValue()
        {
            if (neuron != null)
            {
                _value = neuron.Value;
            }
        }

        #endregion public functions
    }
}