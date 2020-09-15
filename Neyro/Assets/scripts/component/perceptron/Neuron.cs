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

        public Neuron(int layer, int index)
        {
            Layer = layer;
            Index = index;
        }

        public int Layer { get; private set; }

        public int Index { get; private set; }

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