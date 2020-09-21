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
        [SerializeField] private float multiplicator = 5f;
#pragma warning restore

        public List<ILink> Links;

        public Neuron(int layer, int index)
        {
            Layer = layer;
            Index = index;
        }

        public float Multiplicator { get => multiplicator; set => multiplicator = value; }

        public int Layer { get; private set; }

        public int Index { get; private set; }

        public float Value
        {
            get
            {
                return _value;
            }
        }

        public void RecalculateValue()
        {
            float y = Links.Sum(x => x.KoefedValue);
            //_value = Mathf.Pow(1 + Mathf.Exp(-y * Multiplicator), -1); // вариант с [0, 1]
            _value = Mathf.Pow(1 + Mathf.Exp(-y * Multiplicator), -1) * 2 - 1; //вариант с [-1, 1]
        }
    }
}