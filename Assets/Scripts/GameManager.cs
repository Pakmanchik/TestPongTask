using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager: MonoBehaviour
    {
        private LevelInitializer _initializer;
        
        public Ball _ball;
        public Rigidbody2D rb;

        private bool _isDon ;
        
        private void Update()
        {
            BallUpdateTick();
        }

        private void BallUpdateTick()
        {
            if(!_isDon)
            {
                _isDon = true;
                
                Debug.Log($"BallUpdateTick");
                
                Initialize();
                
                rb = _ball.GetComponent<Rigidbody2D>();
                if (rb == null) Debug.Log($"rb = null  ({this})");
                
                _ball.AddShootBall(rb);
            }
        }
        private void Initialize()
        {
            _initializer = GetComponent<LevelInitializer>();
            _ball = _initializer.BallObject;
            if (_ball == null) Debug.Log($"_ballRigidbody = null  ({this})");
        }
        
        
    }
}