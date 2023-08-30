using UnityEngine;

namespace PatternBuilder
{
    public class RacketBuilder
    {
        private Racket _prefab;
        private RacketSkins _skinPrefab;
        private RacketStats _statsPrefab;
        
        public RacketBuilder WithRootPrefab(Racket prefab)
        {
            _prefab = prefab;

            return this;
        }

        public RacketBuilder WithSkin(RacketSkins skin)
        {
            _skinPrefab = skin;
            
            return this;
        }
        
        public RacketBuilder WithStats(RacketStats racketStats)
        {
            _statsPrefab = racketStats;
            Debug.Log($"WithStats {this}");
            return this;
        }

        public Racket Build(Transform container = null)
        {
            var createdRacket = Object.Instantiate(_prefab, container);
           // var createdSkins = Object.Instantiate(_skinPrefab,container);
            
            //createdRacket.SetSkins(createdSkins);
            createdRacket.SetStats(_statsPrefab);

            return createdRacket;
        }

        public RacketBuilder Reset()
        {
            _prefab = null;
            _statsPrefab = null;
            _skinPrefab = null;
            
            return this;
        }
    }
}