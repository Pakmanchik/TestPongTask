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
        
        [Space(15)]
        [SerializeField]
        private Racket _racketRootPrefab;
        [SerializeField]
        private RacketSkins _skinBoltPrefab;
        [SerializeField] 
        private RacketSkins _skinRacketPrefab;

        // TODO: Превратить в ScriptbleObject
        
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

        private void Awake()
        {
            if (_racketRootPrefab == null) Debug.Log($"_racketRootPrefab не найден {this}");
            if (_skinBoltPrefab == null) Debug.Log($"_skinBoltPrefab не найден {this}");
            if (_skinRacketPrefab == null) Debug.Log($"_skinRacketPrefab не найден {this}");
        }

        private void Start()
        {
            RacketBuilder racketBuilder = new RacketBuilder();
            if (_skin == Skin.Bolt)
            {
                var createdBolt = racketBuilder
                                .AddRootPrefab(_racketRootPrefab)
                                .AddName("Bolt")
                                .AddSkin(_skinBoltPrefab)
                                .AddStats(_boltStats)
                                .Build();
                
                Debug.Log(createdBolt);
            }

            else if (_skin == Skin.Classic)
            {
                var createdRacket = racketBuilder
                    .AddRootPrefab(_racketRootPrefab)
                    .AddName("Racket")
                    .AddSkin(_skinRacketPrefab)
                    .AddStats(_racketStats)
                    .Build();
                
                Debug.Log(createdRacket);
            }
            else
            {
                Debug.Log("Не выбран скин");
            }
        }
    }
    public enum Skin : byte
    {
        Classic, //0
        Bolt, //1
    }
}