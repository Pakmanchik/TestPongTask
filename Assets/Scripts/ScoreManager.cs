using System;
using DefaultNamespace;
using Interface;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private LevelInitializer _levelInitializer;
    
    
    [SerializeField]
    private UiElements _uiData;

    [SerializeField] 
    private int _endScore;
    
    private int _playerScore;
    private int _computerScore;
    private string _finalScore;


    private void Initialize()
    {
        _levelInitializer = GetComponent<LevelInitializer>();
    }
    public void PlayerScore()
    {
        Initialize();
            
        _playerScore++;
        _uiData.PlayerScore = _playerScore;
        Debug.Log($"PlayerScore: {_playerScore}");
        
        _uiData.FinalScore = $"{_playerScore} : {_computerScore}";

        if (_playerScore == _endScore) _levelInitializer.GameManager.win = true;
    }

    public void ComputerScore()
    {
        Initialize();
        
        _computerScore++;
        _uiData.ComputerScore = _computerScore;
        Debug.Log($"ComputerScore: {_computerScore}");
        
         _uiData.FinalScore = $"{_playerScore} : {_computerScore}";

         if (_computerScore == _endScore) _levelInitializer.GameManager.win = true;
         
        //resetPosition
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
