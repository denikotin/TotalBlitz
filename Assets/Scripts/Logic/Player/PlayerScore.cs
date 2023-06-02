using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class PlayerScore:MonoBehaviour
    {
        private ScoreService _scoreService;
        private PlayerCollision _playerCollision;

        private void Awake()
        {
            _scoreService = Bootstrap.ServiceLocator.GetService<ScoreService>();
            _playerCollision = GetComponent<PlayerCollision>();
        }

        private void OnEnable() => _playerCollision.OnCoinCollisionEvent += AddCoins;

        private void OnDisable() => _playerCollision.OnCoinCollisionEvent -= AddCoins;

        private void AddCoins() => _scoreService.AddScore(1);
    }
}
