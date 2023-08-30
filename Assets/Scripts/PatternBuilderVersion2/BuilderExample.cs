using System;
using UnityEngine;

namespace PatternBuilderVersion2
{
    public class BuilderExample : MonoBehaviour
    {
        [SerializeField] private Racket _racketRootPrefab;

        /*
        private RacketSkins _greenskinPrefab = new RacketSkins()
        {
              color = Color.green
        };
        */

        [SerializeField]
        private RacketStats _statsPrefab = new RacketStats()
        {
            velosity = 40,
            name = "RacketGreen"
        };

        private void Start()
        {
            var racketBuilder = new RacketBuilder();

            var greenRacketBuilder = racketBuilder
              //  .WithSkin(_greenskinPrefab)
                .WithStats(_statsPrefab)
                .ToString();
            
            Debug.Log($"биллдинг сработал");
        }
    }
    
    
}