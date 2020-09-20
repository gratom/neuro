using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Perceptron
{
    using System.Linq;
    using Tools;

    //[Assert]
    public class Brain : MonoBehaviour
    {
#pragma warning disable

        [SerializeField] private List<Layer> layers;
        [SerializeField] private BrainSettings brainSettings;
        [SerializeField] private List<NervClot> clots;
        [SerializeField] private Visualizer visualizer;

#pragma warning restore

        public BrainSettings BrainSettings => brainSettings;

        public List<Layer> Layers => layers;

        //private void Start()
        //{
        //    CreateNewBrain();
        //    SetRandom();
        //    visualizer?.Init(this);
        //}

        #region public functions

        public void CreateNewBrain()
        {
            layers = new List<Layer>();

            //add base layer for nervs
            layers.Add(new Layer());
            layers[0].neurons = new List<Neuron>();
            int neuronCounter = 0;
            for (int i = 0; i < clots.Count; i++)
            {
                for (int j = 0; j < clots[i].Links.Count; j++, neuronCounter++)
                {
                    layers[0].neurons.Add(new Neuron(0, neuronCounter));
                    layers[0].neurons[neuronCounter].Links = new List<ILink>() { clots[i].Links[j] };
                }
            }

            for (int i = 1; i < BrainSettings.Layers.Length; i++)
            {
                layers.Add(new Layer());
                layers[i].neurons = new List<Neuron>();
                for (int j = 0; j < BrainSettings.Layers[i]; j++)
                {
                    layers[i].neurons.Add(new Neuron(i, j));
                    layers[i].neurons[j].Links = new List<ILink>();

                    for (int k = 0; k < layers[i - 1].neurons.Count; k++)
                    {
                        layers[i].neurons[j].Links.Add(new Link(layers[i - 1].neurons[k], layers[i].neurons[j]));
                    }
                }
            }
        }

        public void SetRandom()
        {
            for (int i = 0; i < layers.Count; i++)
            {
                for (int j = 0; j < layers[i].neurons.Count; j++)
                {
                    for (int k = 0; k < layers[i].neurons[j].Links.Count; k++)
                    {
                        layers[i].neurons[j].Links[k].Koef = Random.Range(-1f, 1f);
                    }
                    //normalization
                    //float sum = layers[i].neurons[j].Links.Sum(x => x.Koef);
                    //for (int k = 0; k < layers[i].neurons[j].Links.Count; k++)
                    //{
                    //    layers[i].neurons[j].Links[k].Koef /= sum;
                    //}
                }
            }
        }

        public void MutateFrom(Brain otherBrain, float value)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                for (int j = 0; j < layers[i].neurons.Count; j++)
                {
                    for (int k = 0; k < layers[i].neurons[j].Links.Count; k++)
                    {
                        layers[i].neurons[j].Links[k].Koef = otherBrain.layers[i].neurons[j].Links[k].Koef + Random.Range(-value, value);
                    }
                }
            }
        }

        public void RecalculateValues()
        {
            for (int i = 0; i < layers.Count; i++)
            {
                for (int j = 0; j < layers[i].neurons.Count; j++)
                {
                    layers[i].neurons[j].RecalculateValue();
                }
            }
        }

        #endregion public functions
    }

    [System.Serializable]
    public class BrainSettings
    {
        public int[] Layers;
    }
}