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
                return neuron.Value * Koef;
            }
        }

        public float Koef { get; set; }

        public float PureValue
        {
            get
            {
                return neuron.Value;
            }
        }

        public int NeuronInLayer => neuron.Layer;

        public int NeuronInIndex => neuron.Index;

        public int NeuronOutLayer => ownNeuron.Layer;

        public int NeuronOutIndex => ownNeuron.Layer;
    }
}