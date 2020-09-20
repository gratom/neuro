using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Perceptron
{
    public class Nerv : ILink
    {
        public delegate float NervValueDelegate();

        private NervValueDelegate nervValueDelegate;

        public float Koef { get; set; }
        public float PureValue { get => nervValueDelegate?.Invoke() ?? 0; }

        public float KoefedValue
        {
            get
            {
                return PureValue * Koef;
            }
        }

        public int NeuronInLayer { get => 0; }
        public int NeuronInIndex { get => 0; }
        public int NeuronOutLayer { get => 0; }
        public int NeuronOutIndex { get => 0; }

        public Nerv(NervValueDelegate nervValueDelegate)
        {
            this.nervValueDelegate = nervValueDelegate;
        }
    }
}