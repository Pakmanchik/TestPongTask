using UnityEngine;

namespace BuilderRacket
{
    public sealed class RacketBuilder
    {
        private Racket _prefabRacket;
        private RacketSkins _skinPrefab;
        private RacketStats _stats;
        private string _racketName;
        
        public RacketBuilder AddRootPrefab(Racket prefab)
        {
            _prefabRacket = prefab;

            return this;
        }

        public RacketBuilder AddSkin(RacketSkins skin)
        {
            _skinPrefab = skin;

            return this;
        }
        
        public RacketBuilder AddStats(RacketStats stats)
        {
            _stats = stats;

            return this;
        }

        public RacketBuilder AddName(string racketName)
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