using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global.Component.Genetic
{
    public abstract class BaseGenetic : MonoBehaviour
    {
#pragma warning disable
        [SerializeField] private GeneticSettings settings;
#pragma warning restore

        public abstract BaseGenable Prefab { get; }
        protected GeneticSettings Settings => settings;

        protected List<BaseGenable> GenableList = new List<BaseGenable>();

        protected bool isSimulated = true;

        #region Unity functions

        private void Start()
        {
            //создать первое поколение

            //запустить корутину
        }

        #endregion Unity functions

        #region public functions

        public void SetSimulator(bool b)
        {
            isSimulated = b;
        }

        public void SwitchSimulation()
        {
            isSimulated = !isSimulated;
        }

        #endregion public functions

        #region private functions

        private IEnumerator GeneticCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Settings.PopulationTime);
                if (isSimulated)
                {
                    //отсеять лучших

                    //сделать поколение на их основе
                }
                else
                {
                    //stop?
                }
            }
        }

        #endregion private functions
    }

    [System.Serializable]
    public class GeneticSettings
    {
#pragma warning disable
        [SerializeField] private int populationCount;
        [SerializeField] private int populationTime;
        [SerializeField, Range(1f, 100f)] private float sampleFromPopulationPercent;
#pragma warning restore

        public int PopulationCount => populationCount;
        public int PopulationTime => populationTime;
        public float SampleFromPopulationPercent => sampleFromPopulationPercent;
        public float SampleFromPopulation => sampleFromPopulationPercent / 100f;
        public int SampleCount => Mathf.Clamp((int)(PopulationCount * SampleFromPopulation), 1, PopulationCount);
    }
}