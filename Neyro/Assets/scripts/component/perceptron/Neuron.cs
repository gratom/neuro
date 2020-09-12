using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Global.Component.Perceptron
{
    [System.Serializable]
    public class Neuron
    {
#pragma warning disable
        [SerializeField] private float _value;
#pragma warning restore

        public List<ILink> Links;

        public float Value
        {
            get
            {
                RecalculateValue();
                return _value;
            }
        }

        private void RecalculateValue()
        {
            _value = Links.Sum(x => x.KoefedValue);
        }
    }
}