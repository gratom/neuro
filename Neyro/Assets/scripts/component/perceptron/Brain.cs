using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Perceptron
{
    using Tools;

    [Assert]
    public class Brain : MonoBehaviour
    {
#pragma warning disable

        [SerializeField] private List<Layer> layers;
        [SerializeField] private BrainSettings brainSettings;
#pragma warning restore

        public BrainSettings BrainSettings => brainSettings;

        public List<Layer> Layers => layers;

        private void Start()
        {
            CreateNewBrain();
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
                    layers[i].neurons.Add(new Neuron());
                    if (i > 0)
                    {
                        layers[i].neurons[j].Links = new List<ILink>();
                        for (int k = 0; k < layers[i - 1].neurons.Count; k++)
                        {
                            layers[i].neurons[j].Links.Add(new Link(layers[i - 1].neurons[k]));
                        }
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