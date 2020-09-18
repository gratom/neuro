using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Organisms.Sworm
{
    using Global.Component.Genetic;

    public class SwormGenetic : BaseGenetic
    {
#pragma warning disable
        [SerializeField] private GameObject prefab;
#pragma warning restore

        public override BaseGenable Prefab => prefab.GetComponent<Sworm>();

        protected override void ActionOnNewGeneration(ref BaseGenable genable)
        {
        }

        protected override void ActionOnSpawn(ref BaseGenable genable)
        {
        }
    }
}