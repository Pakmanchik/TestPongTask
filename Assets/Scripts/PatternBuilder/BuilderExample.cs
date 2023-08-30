using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PatternBuilder
{
    public class BuilderExample : MonoBehaviour
    {
        private RacketStats _greenStats = new ();
        
        private void Start()
        {
            var racketBuilder = new RacketBuilder();

            var greenRacketBuilder = racketBuilder
                .WithStats(_greenStats)
                //.WithSkin(_skinGreenPrefab)
                .Build();
            Debug.Log($"биллдинг сработал");
        }
    }
}