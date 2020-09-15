using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Perceptron
{
    using System.Linq;
    using Tools;

    [Assert]
    public class Brain : MonoBehaviour
    {
#pragma warning disable

        [SerializeField] private List<Layer> layers;
        [SerializeField] private BrainSettings brainSettings;
        [SerializeField] private Visualizer visualizer;

#pragma warning restore

        public BrainSettings BrainSettings => brainSettings;

        public List<Layer> Layers => layers;

        private void Start()
        {
            CreateNewBrain();
            SetRandom();
            visualizer?.Init(this);
        }

        #region public functions

        public void CreateNewBrain()
        {
            layers = new List<Layer>();
            for (int i = 0; i < BrainSettings.Layers.Length; i++)
            {
                layers.Add(new Layer());
                layers[i].neurons = new List<Neuron>();
                for (int j = 0; j < BrainSettings.Layers[i]; j++)
                {
                    layers[i].neurons.Add(new Neuron(i, j));
                    layers[i].neurons[j].Links = new List<ILink>();
                    if (i > 0)
                    {
                        for (int k = 0; k < layers[i - 1].neurons.Count; k++)
                        {
                            layers[i].neurons[j].Links.Add(new Link(layers[i - 1].neurons[k], layers[i].neurons[j]));
                        }
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
                        layers[i].neurons[j].Links[k].Koef = Random.Range(0f, 1f);
                    }
                    float sum = layers[i].neurons[j].Links.Sum(x => x.Koef);
                    for (int k = 0; k < layers[i].neurons[j].Links.Count; k++)
                    {
                        layers[i].neurons[j].Links[k].Koef /= sum;
                    }
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