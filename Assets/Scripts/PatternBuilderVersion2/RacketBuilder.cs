using UnityEngine;

namespace PatternBuilderVersion2
{
    public class RacketBuilder
    {
        private Racket _prefab;
        private RacketSkins _skinPrefab;
        private RacketStats _statPrefab;

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
        
        public RacketBuilder WithStats(RacketStats stats)
        {
            _statPrefab = stats;

            return this;
        }

        public Racket Build(Transform container = null)
        {
            var createdRacket = Object.Instantiate(_prefab);
            
            createdRacket.SetSkins(_skinPrefab);
            createdRacket.SetStats(_statPrefab);

            return createdRacket;
        }
    }
}