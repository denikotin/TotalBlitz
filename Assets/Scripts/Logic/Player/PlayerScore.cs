using Assets.Scripts.Data.PlayerData;
using Assets.Scripts.Logic.Player;
using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class PlayerScore:MonoBehaviour
    {
        private ScoreService _scoreService;
        private RecordService _recordService;
        private SaveLoadService _saveLoadService;
        private PlayerCollision _playerCollision;
        private PlayerLose _playerLose;

        private void Awake()
        {
            _scoreService = Bootstrap.ServiceLocator.GetService<ScoreService>();
            _recordService = Bootstrap.ServiceLocator.GetService<RecordService>();
            _saveLoadService = Bootstrap.ServiceLocator.GetService<SaveLoadService>();
            _playerCollision = GetComponent<PlayerCollision>();
            _playerLose = GetComponent<PlayerLose>();
        }

        private void OnEnable()
        {
            _playerCollision.OnCoinCollisionEvent += AddCoins;
            _playerLose.OnPlayerLoseEvent += WriteScores;
        }

        private void OnDisable()
        {
            _playerCollision.OnCoinCollisionEvent -= AddCoins;
            _playerLose.OnPlayerLoseEvent -= WriteScores;
        }

        private void AddCoins() => _scoreService.AddScore(1);
        private void WriteScores()
        {
            _recordService.WriteRecord(new Record(_scoreService.GetScore()));
            _saveLoadService.Save();
        }
    }
}
