using Interface;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _playerscore = 0;
    private int _computerscore = 0;

    private PauseGame _pauseGame;

    [SerializeField] 
    private Ball _ball;
    [SerializeField] 
    private Text _playerScoreText;
    [SerializeField] 
    private Text _computerScoreText;
    [SerializeField] 
    private Text _finalScoreText;

    private void Awake()
    {
        _pauseGame = GetComponent<EndGame>();
        
        if (_pauseGame == null) Debug.Log($"ScoreManager не нашел PauseGame {this}");
        if (_ball == null) Debug.Log($"ScoreManager не нашел _ball {this}");
        if (_playerScoreText == null) Debug.Log($"ScoreManager не нашел _playerScoreText {this}");
        if (_computerScoreText == null) Debug.Log($"ScoreManager не нашел _computerScoreText {this}");
        if (_finalScoreText == null) Debug.Log($"ScoreManager не нашел _finalScoreText {this}");
    }

    public void PlayerScore()
    {
        _playerscore++;
        Debug.Log($"PlayerScore: {_playerscore}");

        ReloadScore();

        if (_playerscore == 7) _pauseGame.PauseGame();

        _ball.ResetPosition();
    }

    public void ComputerScore()
    {
        _computerscore++;
        Debug.Log($"ComputerScore: {_computerscore}");

        ReloadScore();

        if (_computerscore == 7) _pauseGame.PauseGame();

        _ball.ResetPosition();
    }

    public void ReloadScore()
    {
        _playerScoreText.text = _playerscore.ToString();
        _computerScoreText.text = _computerscore.ToString();

        _finalScoreText.text = $"{_playerscore} : {_computerscore}";
    }
}
