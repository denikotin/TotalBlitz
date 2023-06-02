using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class LobbySceneManager:MonoBehaviour
    {
        private Factory _factory;
        private AssetsPaths _assetsPaths;

        private void Start()
        {
            _factory = Bootstrap.ServiceLocator.GetService<Factory>();
            _assetsPaths = Bootstrap.ServiceLocator.GetService<AssetsPaths>();
            ConstructLobbyUI();
        }

        private void ConstructLobbyUI() => _factory.Create(_assetsPaths.LOBBY_UI);
    }
}
