using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class PlayerScore:MonoBehaviour
    {
        private ScoreService _scoreService;
        private PlayerCollision _playerCollision;

        public void Construct(ScoreService scoreService,PlayerCollision playerCollision)
        {
            _scoreService = scoreService;
            _playerCollision = playerCollision;
        }

        private void Start() => _playerCollision.OnCoinCollisionEvent += AddCoins;

        private void OnDisable() => _playerCollision.OnCoinCollisionEvent -= AddCoins;

        private void AddCoins() => _scoreService.AddScore(1);
    }
}
