using Assets.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

public class LoadLobbyButton : MonoBehaviour
{
    [SerializeField] Button _loadLobbyButton;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader = Bootstrap.ServiceLocator.GetService<SceneLoader>();
        _loadLobbyButton.onClick.AddListener(LoadLobby);
    }

    private void LoadLobby() => _sceneLoader.Load("Lobby");
}
