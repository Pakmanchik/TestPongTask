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
        
        [SerializeField] 
        private CharacterRacket _characterRacket; 
        
        // TODO: Превратить в ScriptbleObject

        private int _hp, _level, _speed;


        private RacketStats _boltStats;
        
        private RacketStats _racketStats = new()
        {
            hp = 100,
            level = 2,
            speed = 20
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
                                .AddStats(_characterRacket.racketStats)
                                .Build();

                Debug.Log($"Создан {createdBolt}");
            }

            else if (_skin == Skin.Classic)
            {
                var createdRacket = racketBuilder
                    .AddRootPrefab(_racketRootPrefab)
                    .AddName("Racket")
                    .AddSkin(_skinRacketPrefab)
                    .AddStats(_racketStats)
                    .Build();
                
                Debug.Log($"Создан {createdRacket}");
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