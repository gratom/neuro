using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Organisms.Sworm
{
    using Global.Component.Genetic;
    using Global.Component.Perceptron;

    public class SwormGenetic : BaseGenetic
    {
#pragma warning disable

        [SerializeField] private GameObject prefab;

#pragma warning restore

        public override BaseGenable Prefab => prefab.GetComponent<Sworm>();

        protected override void ActionOnNewGeneration(ref BaseGenable genable, int index)
        {
            genable.Refresh();
            genable.transform.position = new Vector3(0, 1, index * 2);
        }

        protected override void ActionOnSpawn(ref BaseGenable genable, int index)
        {
            genable.transform.position = new Vector3(0, 1, index * 2);
        }
    }
}