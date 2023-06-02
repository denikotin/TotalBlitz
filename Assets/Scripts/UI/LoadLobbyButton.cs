using Assets.Scripts.Data.PlayerData;
using Assets.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

public class LoadLobbyButton : MonoBehaviour
{
    [SerializeField] Button _loadLobbyButton;
    private SceneLoader _sceneLoader;
    private RecordService _recordService;
    private ScoreService _scoreService;
    private SaveLoadService _saveLoadService;

    private void Awake()
    {
        _sceneLoader = Bootstrap.ServiceLocator.GetService<SceneLoader>();
        _recordService = Bootstrap.ServiceLocator.GetService<RecordService>();
        _scoreService = Bootstrap.ServiceLocator.GetService<ScoreService>();
        _saveLoadService = Bootstrap.ServiceLocator.GetService<SaveLoadService>();
        _loadLobbyButton.onClick.AddListener(LoadLobby);
    }

    private void LoadLobby()
    {
        Time.timeScale = 1.0f;
        WriteScores();
        _sceneLoader.Load("Lobby");
    }

    private void WriteScores()
    {
        _recordService.WriteRecord(new Record(_scoreService.GetScore()));
        _saveLoadService.Save();
    }
}
