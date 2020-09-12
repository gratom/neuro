using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Perceptron
{
    public interface ILink
    {
        float Koef { get; set; }
        float PureValue { get; }
        float KoefedValue { get; }
    }

    public class Link : ILink
    {
#pragma warning disable
        [SerializeField] private float _value;
#pragma warning restore

        public Neuron neuron;

        public Link(Neuron neuron)
        {
            this.neuron = neuron;
        }

        public float KoefedValue
        {
            get
            {
                _value = neuron.Value;
                return _value * Koef;
            }
            private set
            {
                _value = value;
            }
        }

        public float Koef { get; set; }

        public float PureValue => _value;
    }
}