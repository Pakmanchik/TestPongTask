using UnityEngine;

namespace PatternBuilderVersion3
{
    public class RacketBuilder
    {
        private Racket _prefabRacket;
        private RacketSkins _skinPrefab;
        private RacketStats _stats;
        private string _racketName;
        
        public RacketBuilder WithRootPrefab(Racket prefab)
        {
            _prefabRacket = prefab;

            return this;
        }

        public RacketBuilder WithSkin(RacketSkins skin)
        {
            _skinPrefab = skin;

            return this;
        }
        
        public RacketBuilder WithStats(RacketStats stats)
        {
            _stats = stats;

            return this;
        }

        public RacketBuilder WithName(string racketName)
        {
            _racketName = racketName;

            return this;
        }

        public Racket Build(Transform container = null)
        {
            var createdRacket = Object.Instantiate(_prefabRacket,container);
            var createdSkin = Object.Instantiate(_skinPrefab);
            
            createdRacket.SetSkins(createdSkin);
            createdRacket.SetName(_racketName);
            createdRacket.SetStats(_stats);

            return createdRacket;
        }
        
    }
}