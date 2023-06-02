using Assets.Scripts.Data.PlayerData;
using Assets.Scripts.Services;
using System;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class LobbySceneManager:MonoBehaviour
    {
        private Factory _factory;
        private AssetsPaths _assetsPaths;
        private SaveLoadService _saveLoadService;
        private RecordService _recordService;

        private void Start()
        {
            _factory = Bootstrap.ServiceLocator.GetService<Factory>();
            _assetsPaths = Bootstrap.ServiceLocator.GetService<AssetsPaths>();
            _saveLoadService = Bootstrap.ServiceLocator.GetService<SaveLoadService>();
            _recordService = Bootstrap.ServiceLocator.GetService<RecordService>();
            LoadRecords();
            ConstructLobbyUI();
        }

        private void LoadRecords()
        {
            PlayerRecord playerRecord = _saveLoadService.Load();
            if(playerRecord == null ) 
            {
                _recordService.SetPlayerRecord(new PlayerRecord());
            }
            else
            {
                _recordService.SetPlayerRecord(playerRecord);
            }
        }

        private void ConstructLobbyUI() => _factory.Create(_assetsPaths.LOBBY_UI);
    }
}
