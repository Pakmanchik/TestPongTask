using Interface;
using UnityEngine;

    public sealed class GameManager: MonoBehaviour
    {
        private bool _goUpdate;
        
        private ScoreManager _scoreManager;
        private IPauseGame _pauseGame;
        
        private RacketComputer _racketComputer;
        
        private IHaveShootBall _shootBall;
        
        
        public void InitializerGameManager(GameObject targetObject,GameObject computerObject)
        {
            _shootBall = targetObject.GetComponent<Ball>();
            
            _scoreManager = GetComponent<ScoreManager>();
            _pauseGame = GetComponent<EndGame>();
            
            _racketComputer = computerObject.GetComponent<RacketComputer>();
            
            if(_shootBall == null) Debug.Log($"_shootBall = null  ({this})");
        }

        private void Update()
        {
            if (_goUpdate == false)
            {
                _goUpdate = true;
                
                _shootBall.ShootBall();

                SubscribeToEvents();
            }
        }

        private void FixedUpdate()
        {
            _racketComputer.MoveRacket();
        }

        private void EndGame()
        {
            _pauseGame.PauseGame();
            this.enabled = false;
        }

        private void SubscribeToEvents()
        {
            _scoreManager.OnFinishScore += EndGame;
        }
    }
