using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _button;

    private void Awake()
    {
        _button.SetActive(false);
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
