using Interface;
using UnityEngine;

    public class GameManager: MonoBehaviour
    {  
        [HideInInspector]
        public bool win;
        
        private LevelInitializer _levelInitializer;
        private ScoreManager _scoreManager;
        private IHaveMoveRacket _moveRacket;
        private bool _startUpdate;

        private void Start()
        {
            _levelInitializer = GetComponent<LevelInitializer>();
        }

        private void Update()
        {
            if (!_startUpdate)
            {
                if(_levelInitializer == null)Debug.Log($"_levelInitializer.BallRigidbody == null");
                
                _startUpdate = true;
                
                Debug.Log($"Update включен");
                
                _levelInitializer.BallScrypt.AddShootBall();
                Debug.Log($"пнул мяч");
            }
            EndGame();
        }

        private void FixedUpdate()
        {
            UpdateTickRacketComputer();
        }

        private void UpdateTickRacketComputer()
        {
            _levelInitializer.RacketPlayerScrypt.UpdateTicKPlayer();
            _levelInitializer.PlayerMove.MoveRacket();
        }

        private void EndGame()
        {
            if (win)
            {
                win = false;
                Debug.Log("Победа");
                _levelInitializer.PauseGame.PauseGame();
                this.enabled = false;
            }
        }
    }
