using Assets.Scripts.Services;
using System;
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
            GenerateLevel();
            CreateMoney();
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

        }

        private void CreateMoney()
        {

        }

        private void GenerateLevel()
        {
            
        }

        private void CreateUI()
        {
            GameObject gameUI = _factory.Create(_assetsPaths.GAME_UI);
        }
    }
}
