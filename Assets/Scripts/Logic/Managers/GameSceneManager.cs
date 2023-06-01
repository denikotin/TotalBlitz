using UnityEngine;
using Assets.Scripts.Services;
using Assets.Scripts.Logic.Camera;
using System.Collections.Generic;

namespace Assets.Scripts.Logic
{
    public class GameSceneManager:MonoBehaviour
    {
        [SerializeField] int _enemyCount;

        private Factory _factory;
        private AssetsPaths _assetsPaths;
        private ScoreService _scoreService;
        private GameObject _mapGenerator;

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
            _scoreService = Bootstrap.ServiceLocator.GetService<ScoreService>();
        }

        private void CreateEnemies()
        {
            List<Transform> floors = new List<Transform>();
            for(int i=0; i < _mapGenerator.transform.childCount; i++)
            {
                Transform child = _mapGenerator.transform.GetChild(i);
                if(child.tag == "Floor")
                {
                    floors.Add(child);
                }
            }

            for(int i=0; i < _enemyCount; i++) 
            {
                GameObject enemy = _factory.Create(_assetsPaths.ENEMY);
                int r = Random.Range(0, floors.Count-1);
                enemy.transform.position = floors[r].position;
            }
        }

        private void CreatePlayer()
        {
            GameObject player = _factory.Create(_assetsPaths.PLAYER);
            player.GetComponent<MoveController>().Construct(new PlayerInputService(player.GetComponentInChildren<CameraController>()));
            player.GetComponent<PlayerScore>().Construct(_scoreService, player.GetComponent<PlayerCollision>());
        }

        private void CreateMapGenerator()
        {
            _mapGenerator = _factory.Create(_assetsPaths.MAZE_SPAWNER);
        }

        private void CreateUI() => _factory.Create(_assetsPaths.GAME_UI);
    }
}
