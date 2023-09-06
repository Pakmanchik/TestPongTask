using UnityEngine;

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
                
                _levelInitializer.BallScrypt.AddShootBall(_levelInitializer.BallRigidbody);
            }
            UpdateTickRacketComputer();
        }

        private void UpdateTickRacketComputer()
        {
            _levelInitializer.RacketComputerScrypt.MoveRacket(_levelInitializer.BallTransform
                ,_levelInitializer.RacketComputerTransform
                ,_levelInitializer.SpeedComputerRacket
                ,_levelInitializer.RigidbodyComputer);
        }
        

        private void EndGame()
        {
            if (win)
            {
                win = false;
                Debug.Log("Победа");
                _levelInitializer.PauseGame.PauseGame();
            }
        }
    }
