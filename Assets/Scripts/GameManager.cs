using System;
using Interface;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class GameManager: MonoBehaviour
    {  
        private LevelInitializer _levelInitializer;
        private ScoreManager _scoreManager;

        [HideInInspector]
        public bool startUpdate;
        public bool win;

        private int _scoreEndGame;
        private void Start()
        {
            _levelInitializer = GetComponent<LevelInitializer>();
        }

        private void Update()
        {
            EndGame();
            if (!startUpdate)
            {
                startUpdate = true;
                Debug.Log($"Update включен");
                
                _levelInitializer.BallScrypt.AddShootBall(_levelInitializer.BallRigidBody);
            }
        }

        private void EndGame()
        {
            if (win)
            {
                win = false;
                Debug.Log("Победа");
                _levelInitializer.IPauseGame.PauseGame();
            }
        }
    }
}