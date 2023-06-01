using Assets.Scripts.Services;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class LobbySceneManager:MonoBehaviour
    {
        private Factory _factory;
        private AssetsPaths _assetsPaths;
        private SceneLoader _sceneLoader;

        public void Construct(ServiceLocator serviceLocator)
        {
            _factory = serviceLocator.GetService<Factory>();
            _assetsPaths = serviceLocator.GetService<AssetsPaths>();
            _sceneLoader = serviceLocator.GetService<SceneLoader>();
        }

        private void Start()
        {
            ConstructLobbyUI();
        }

        private void ConstructLobbyUI()
        {
            GameObject lobbyUI = _factory.Create(_assetsPaths.LOBBY_UI);
            lobbyUI.GetComponentInChildren<StartGameButton>().Construct(_sceneLoader);
        }
    }
}
