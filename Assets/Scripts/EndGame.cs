using Interface;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class EndGame : MonoBehaviour, IPauseGame
{
    private GameObject _ball;
    
    private GameObject _button;

    public void InitializeEndGame(GameObject ball,GameObject buttonEndGame)
    {
        _ball = ball;
        _button = buttonEndGame;
        
        _button.SetActive(false);
        
        if (_ball == null) Debug.Log($"EndGame не нашел _ball {this}");
        if (_button == null) Debug.Log($"EndGame не нашел _button {this}");
    }

    public void PauseGame()
    {
        _button.SetActive(true);
        
        Destroy(_ball);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
