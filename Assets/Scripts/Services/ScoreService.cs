using System;

namespace Assets.Scripts.Services
{
    public class ScoreService: IService
    {
        private int _score;
        public event Action OnCoinsChangedEvent;

        public ScoreService(int value = 0) => _score = value;

        public void AddScore(int value)
        {
            _score += value;
            OnCoinsChangedEvent?.Invoke();
        }

        public int GetScore() => _score;
    }
}
