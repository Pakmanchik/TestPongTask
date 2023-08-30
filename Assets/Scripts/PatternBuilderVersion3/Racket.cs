using UnityEngine;
using UnityEngine.Serialization;

namespace PatternBuilderVersion3
{
    public class Racket : MonoBehaviour
    {
        [SerializeField] 
        private Transform _skinContainer;
        
        public RacketStats Stats { get; private set; }
        public string Name { get; private set; }
        
        private RacketSkins _skin;

        
        public void SetName(string name)
        {
            Name = name;

            gameObject.name = $"{name} (Racket)";
        }
        
        public void SetStats(RacketStats stats)
        {
            Stats = stats;
        }
        
        public void SetSkins(RacketSkins skin)
        {
            _skin = skin;

            skin.transform.SetParent(_skinContainer);
        }

        public override string ToString()
        {
            var line = $"Racket: Skin = {Name}, Stats: Level = {Stats.Level}, HP = {Stats.Hp}, Speed = {Stats.Speed}";

            return line;
        }
    }
}