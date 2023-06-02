using Assets.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class StartGameButton: MonoBehaviour
    {
        [SerializeField] Button _startButton;
        private SceneLoader _sceneLoader;

        private void Start()
        {
            _sceneLoader = Bootstrap.ServiceLocator.GetService<SceneLoader>();
            _startButton.onClick.AddListener(StartGame);
        }

        private void StartGame() => _sceneLoader.Load("Game");
    }
}
