using UnityEngine;
using UnityEngine.UI;

public class PauseGameButton : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;
    [SerializeField] Button _pauseButton;

    public void Awake() => _pauseButton.onClick.AddListener(Pause);
    public void Pause()
    {
        Time.timeScale = 0f;
        _mainMenu.SetActive(true);
    }
}
