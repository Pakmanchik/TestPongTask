using System;
using Interface;
using UnityEngine;
using UnityEngine.UI;

public sealed class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private UiElements _uiData;
    
    [SerializeField] 
    private int _endScore;
    public event Action OnFinishScore;
    
    private int _playerScore;
    private int _computerScore;
    private string _finalScore;

    private GameManager _gameManager;
    private IHaveResetPosition _resetPosition;
    
    public void InitializeScoreManager(GameObject resetObject)
    {
        _gameManager = GetComponent<GameManager>();

        _resetPosition = resetObject.GetComponent<Ball>();
        
        if(_gameManager == null) Debug.Log($"_gameManager = null  ({this})");
        if(_resetPosition == null) Debug.Log($"_resetPosition = null  ({this})");
    }
    public void PlayerScoreInc()
    {
        _playerScore++;
        
        _uiData.PlayerScore = _playerScore;
        
        _uiData.FinalScore = $"{_playerScore} : {_computerScore}";

        if (_playerScore == _endScore) OnFinishScore?.Invoke();
        
        _resetPosition.ResetPosition();
    }

    public void ComputerScoreInc()
    {
        _computerScore++;
        
        _uiData.ComputerScore = _computerScore;
        
         _uiData.FinalScore = $"{_playerScore} : {_computerScore}";

         if (_computerScore == _endScore) OnFinishScore?.Invoke();
         
        _resetPosition.ResetPosition();
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
