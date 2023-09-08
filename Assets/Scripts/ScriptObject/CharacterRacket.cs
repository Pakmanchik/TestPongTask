using UnityEngine;

namespace BuilderRacket
{
    [CreateAssetMenu(fileName = "New CharacterRacket", menuName = "Character Racket", order = 51)] 
    public class CharacterRacket : ScriptableObject
    {
        [SerializeField] 
        private  int _hp;
        [SerializeField] 
        private int _level;
        [SerializeField] 
        private int _speed;

        public int Hp => _hp;

        public int Level => _level;

        public int Speed => _speed;

        public RacketStats racketStats = new()
        {
            hp = 1,
            level = 1,
            speed = 1,
        };
    }
}