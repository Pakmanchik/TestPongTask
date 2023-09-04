using System;
using DefaultNamespace;
using Interface;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private UiElements _uiData;
    
    private int _playerScore;
    private int _computerScore;
    private string _finalScore;

    private  IBallResetPosition _IballResetPosition;
    private IPauseGame _IpauseGame;

    private GameManager _gameManager;
    

    private void Awake()
    {
       _IpauseGame = GetComponent<IPauseGame>();
       _IballResetPosition = GetComponent<Ball>();
       _gameManager = GetComponent<GameManager>();
       
        
        CheckReferences();
    }

    private void CheckReferences()
    {
        if (_IpauseGame == null) Debug.Log($"ScoreManager не нашел PauseGame {this}");
        if (_IballResetPosition == null) Debug.Log($"ScoreManager не нашел IBallResetPosition {this}");
        if (_gameManager == null) Debug.Log($"ScoreManager не нашел _gameManager {this}");
    }

    public void PlayerScore()
    {
       _playerScore++;
        _uiData.PlayerScore = _playerScore;
        Debug.Log($"PlayerScore: {_playerScore}");

        if (_playerScore == 2) _IpauseGame.PauseGame();

        Debug.Log($"                  {_gameManager._ball.GetComponent<Rigidbody2D>()} ");

        _IballResetPosition.ResetPosition(_gameManager.rb);
    }

    public void ComputerScore()
    {
        _computerScore++;
        _uiData.ComputerScore = _computerScore;
        Debug.Log($"ComputerScore: {_computerScore}");
        
         _uiData.FinalScore = $"{_playerScore} : {_computerScore}"; // TODO: Не могу присвоить 

        if (_computerScore == 2) _IpauseGame.PauseGame();

        Debug.Log($"                  {_gameManager._ball.GetComponent<Rigidbody2D>()} ");
        _IballResetPosition.ResetPosition(_gameManager.rb);
    }


    [Serializable]
    private class UiElements
    {
        [SerializeField]
        private Text _playerScoreText;
        [SerializeField]
        private Text _computerScoreText;
        [SerializeField]
        private Text _finalScoreText;

        public int PlayerScore
        {
            get
            {
                var scoreText = _playerScoreText.text;

                if (!Int32.TryParse(scoreText, out int score)) return 0;

                return score;
            }
            set => _playerScoreText.text = value.ToString();
        }

        public int ComputerScore
        {
            get
            {
                var scoreText = _computerScoreText.text;

                if (!Int32.TryParse(scoreText, out int score)) return 0;

                return score;
            }
            set => _computerScoreText.text = value.ToString();
        }
        public string FinalScore
        {
            get => _finalScoreText.text;
            
            set => _finalScoreText.text = value;
        }
    }
}
