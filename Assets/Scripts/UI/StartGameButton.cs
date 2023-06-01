using Assets.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class StartGameButton: MonoBehaviour
    {
        [SerializeField] Button _startButton;
        private Factory _factory;
        private SceneLoader _sceneLoader;
        private GameObject _gameSceneManagerPrefab;
        public void Construct(Factory factory, SceneLoader sceneLoader, GameObject gameSceneManagerPrefab)
        {
            _factory = factory;
            _sceneLoader = sceneLoader;
            _gameSceneManagerPrefab = gameSceneManagerPrefab;
        }

        private void Start() => _startButton.onClick.AddListener(StartGame);

        private void StartGame() => _sceneLoader.Load("Game", onLoaded:CreateGameSceneManager);

        private void CreateGameSceneManager()
        {
            GameObject gameSceneManagerGO = _factory.Create(_gameSceneManagerPrefab);
            Debug.Log("dasda");
        }
    }
}
