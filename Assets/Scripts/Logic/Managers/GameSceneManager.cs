using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class GameSceneManager:MonoBehaviour
    {

        private Factory _factory;
        private AssetsPaths _assetsPaths;

        private void Start()
        {
            GetServices();
            CreateUI();
            CreateMapGenerator();
            CreatePlayer();
            CreateEnemies();
        }

        private void GetServices()
        {
            _factory = Bootstrap.ServiceLocator.GetService<Factory>();
            _assetsPaths = Bootstrap.ServiceLocator.GetService<AssetsPaths>();
        }

        private void CreateEnemies()
        {

        }

        private void CreatePlayer()
        {
            GameObject player = _factory.Create(_assetsPaths.PLAYER);
        }

        private void CreateMapGenerator()
        {
            GameObject  mapGenerator = _factory.Create(_assetsPaths.MAZE_SPAWNER);
        }

        private void CreateUI()
        {
            GameObject gameUI = _factory.Create(_assetsPaths.GAME_UI);
        }
    }
}
