using Assets.Scripts.Services;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreUI;

    private ScoreService _scoreService;
    private void Awake() => _scoreService = Bootstrap.ServiceLocator.GetService<ScoreService>();

    private void Start() => _scoreService.OnCoinsChangedEvent += UpdateScoreUI;

    private void OnDisable() => _scoreService.OnCoinsChangedEvent -= UpdateScoreUI;

    private void UpdateScoreUI() => _scoreUI.text = _scoreService.GetScore().ToString();
}
