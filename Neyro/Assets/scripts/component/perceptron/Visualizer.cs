using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Global.Component.Perceptron
{
    using Tools;

    [Assert]
    public class Visualizer : MonoBehaviour
    {
#pragma warning disable

        [SerializeField] private float updateTime;
        [SerializeField] private float defaultLinkWidth;
        [SerializeField] private Material MaterialNeuron;
        [SerializeField] private Material MaterialLink;

#pragma warning restore

        private Brain brain;

        private List<VisualLayer> layers = new List<VisualLayer>();

        private bool isInit = false;

        #region public functions

        public void Init(Brain brain)
        {
            if (!isInit)
            {
                this.brain = brain;

                for (int i = 0; i < brain.Layers.Count; i++)
                {
                    layers.Add(new VisualLayer());
                    layers[i].neurons = new List<VisualNeuron>();
                    for (int j = 0; j < brain.Layers[i].neurons.Count; j++)
                    {
                        layers[i].neurons.Add(new VisualNeuron(new List<LineRenderer>(), MaterialNeuron));
                        layers[i].neurons[j].neuron.transform.position = new Vector3(i, j);
                        for (int k = 0; k < brain.Layers[i].neurons[j].Links.Count; k++)
                        {
                            layers[i].neurons[j].links.Add(new GameObject().AddComponent<LineRenderer>());
                            layers[i].neurons[j].links[k].SetPositions(new Vector3[] {
                                new Vector3(i,j),
                                new Vector3(brain.Layers[i].neurons[j].Links[k].NeuronInLayer, brain.Layers[i].neurons[j].Links[k].NeuronInIndex)
                            });
                            layers[i].neurons[j].links[k].material = MaterialLink;
                        }
                    }
                }

                StartCoroutine(UpdateCoroutine());
                isInit = true;
            }
        }

        #endregion public functions

        #region private functions

        private void Visualize()
        {
            for (int i = 0; i < brain.Layers.Count; i++)
            {
                for (int j = 0; j < brain.Layers[i].neurons.Count; j++)
                {
                    for (int k = 0; k < brain.Layers[i].neurons[j].Links.Count; k++)
                    {
                        layers[i].neurons[j].links[k].widthMultiplier = defaultLinkWidth * brain.Layers[i].neurons[j].Links[k].Koef;
                    }
                }
            }
        }

        private IEnumerator UpdateCoroutine()
        {
            while (true)
            {
                Visualize();
                yield return new WaitForSeconds(updateTime);
            }
        }

        #endregion private functions
    }

    public class VisualLayer
    {
        public List<VisualNeuron> neurons;
    }

    public class VisualNeuron
    {
        public GameObject neuron;
        public List<LineRenderer> links;

        public VisualNeuron(List<LineRenderer> links, Material material)
        {
            this.links = links;
            neuron = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            neuron.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            neuron.GetComponent<MeshRenderer>().material = material;
        }
    }
}