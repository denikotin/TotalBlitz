using Assets.Scripts.Services;
using TMPro;
using UnityEngine;

public class TotalCoins : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _totalScore;

    private ScoreService _scoreService;
    private void Awake() => _scoreService = Bootstrap.ServiceLocator.GetService<ScoreService>();

    private void OnEnable() => _totalScore.text = ($"Ты собрал {_scoreService.GetScore()} монет");
}
