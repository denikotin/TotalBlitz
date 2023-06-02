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
        private GameObject _mapGenerator;
        private GameObject _player;

        private void Start()
        {
            GetServices();
            ConstructMap();
            ConstructPlayer();
            ConstructEnemies();
            ConstructUI();
        }

        private void GetServices()
        {
            _factory = Bootstrap.ServiceLocator.GetService<Factory>();
            _assetsPaths = Bootstrap.ServiceLocator.GetService<AssetsPaths>();
        }

        private void ConstructEnemies()
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
                enemy.GetComponent<MoveController>().Construct(new EnemyInputService(enemy.transform,_player.transform));
                int r = Random.Range(0, floors.Count-1);
                enemy.transform.position = floors[r].position;
            }
        }

        private void ConstructPlayer()
        {
            _player = _factory.Create(_assetsPaths.PLAYER);
            _player.GetComponent<MoveController>().Construct(new PlayerInputService(_player.GetComponentInChildren<CameraController>()));
        }

        private void ConstructMap() => _mapGenerator = _factory.Create(_assetsPaths.MAZE_SPAWNER);

        private void ConstructUI()
        {
            GameObject ui = _factory.Create(_assetsPaths.GAME_UI);
            ui.GetComponent<LoseGame>().Construct(_player.GetComponent<PlayerCollision>());
        }
    }
}
