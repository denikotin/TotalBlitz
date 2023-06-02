using Assets.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

public class ReloadGameButton : MonoBehaviour
{
    [SerializeField] Button _reloadGameButton;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader = Bootstrap.ServiceLocator.GetService<SceneLoader>();
        _reloadGameButton.onClick.AddListener(Reload);
    }

    private void Reload() => _sceneLoader.Load("Game");
}
