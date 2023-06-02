using Assets.Scripts.Logic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    [SerializeField] GameObject _loseMenu;
    [SerializeField] GameObject _score;
    [SerializeField] GameObject _pauseButton;

    private PlayerCollision _playerCollision;

    public void Construct(PlayerCollision playerCollision) => _playerCollision = playerCollision;

    private void Start() => _playerCollision.OnEnemyCollisionEvent += ShowLoseMenu;

    private void OnDisable() => _playerCollision.OnEnemyCollisionEvent -= ShowLoseMenu;

    private void ShowLoseMenu()
    {
        _score.SetActive(false);
        _pauseButton.SetActive(false);
        _loseMenu.SetActive(true);
    }
}
