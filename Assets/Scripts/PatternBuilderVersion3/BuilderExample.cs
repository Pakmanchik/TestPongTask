using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

namespace PatternBuilderVersion3
{
    public class BuilderExample : MonoBehaviour
    {
       
        [SerializeField]
        private Skin _skin;
        [SerializeField]
        private Racket _racketRootPrefab;
        [SerializeField]
        private RacketSkins _skinBoltPrefab;
        [SerializeField] 
        private RacketSkins _skinRacketPrefab;

        private RacketStats _boltStats = new RacketStats
        {
            Hp = 50,
            Level = 1,
            Speed = 10
        };
        
        private RacketStats _racketStats = new RacketStats
        {
            Hp = 100,
            Level = 2,
            Speed = 20
        };

        private void Start()
        {
            RacketBuilder racketBuilder = new RacketBuilder();
            if (_skin == Skin.Bolt)
            {
                var createdBolt = racketBuilder
                                .WithRootPrefab(_racketRootPrefab)
                                .WithName("Bolt")
                                .WithSkin(_skinBoltPrefab)
                                .WithStats(_boltStats)
                                .Build();
                
                Debug.Log(createdBolt);
            }

            else if (_skin == Skin.Racket)
            {
                var createdRacket = racketBuilder
                    .WithRootPrefab(_racketRootPrefab)
                    .WithName("Racket")
                    .WithSkin(_skinRacketPrefab)
                    .WithStats(_racketStats)
                    .Build();
                
                Debug.Log(createdRacket);
            }
            else
            {
                Debug.Log("Не выбран скин");
            }
        }
    }
    public enum Skin
    {
        Bolt, //0
        Racket //1
    }
}