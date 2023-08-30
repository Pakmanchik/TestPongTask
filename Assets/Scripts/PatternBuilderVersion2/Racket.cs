using UnityEngine;

namespace PatternBuilderVersion2
{
    public class Racket : MonoBehaviour
    {
        [SerializeField] private BuilderExample _buildExample;
        public RacketStats Stats { get; private set; }
        public RacketSkins Skins { get; private set; }

        public void SetStats(RacketStats racketStats)
        {
            Stats = racketStats;
             
        }
        
        public void SetSkins(RacketSkins racketSkins)
        {
            Skins = racketSkins;
            
            //GetComponent<SpriteRenderer>().color = _buildExample. ;
        }
        
        public override string ToString()
        {
            var line = $"Stats: Velosity = {Stats.velosity}, Racket = {Stats.name}";
            return line;
        }
        
        
        
        
    }
}