using Interface;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour, PauseGame
{
    [SerializeField] 
    private GameObject _ball;
    [SerializeField] 
    private GameObject _button;

    private void Awake()
    {
        _button.SetActive(false);
        
        if (_ball == null) Debug.Log($"EndGame не нашел _ball {this}");
        if (_button == null) Debug.Log($"EndGame не нашел _button {this}");
    }

    public void PauseGame()
    {
        _button.SetActive(true);
        Object.Destroy(_ball);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
