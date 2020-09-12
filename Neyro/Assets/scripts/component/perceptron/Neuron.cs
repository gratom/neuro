using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Perceptron
{
    public class Neuron
    {
#pragma warning disable
        [SerializeField] private List<Link> links;
#pragma warning restore

        public List<Link> Links { get => links; private set => links = value; }

        public float Value { get; private set; }

        #region public functions

        public void RecalculateValue()
        {
        }

        #endregion public functions
    }
}