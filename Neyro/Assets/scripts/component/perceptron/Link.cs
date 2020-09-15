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
        int NeuronInLayer { get; }
        int NeuronInIndex { get; }
        int NeuronOutLayer { get; }
        int NeuronOutIndex { get; }
    }

    public class Link : ILink
    {
#pragma warning disable
        [SerializeField] private float _value;
#pragma warning restore

        public Neuron neuron;

        public Neuron ownNeuron;

        public Link(Neuron neuron, Neuron ownNeuron)
        {
            this.neuron = neuron;
            this.ownNeuron = ownNeuron;
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

        public int NeuronInLayer => neuron.Layer;

        public int NeuronInIndex => neuron.Index;

        public int NeuronOutLayer => ownNeuron.Layer;

        public int NeuronOutIndex => ownNeuron.Layer;
    }
}