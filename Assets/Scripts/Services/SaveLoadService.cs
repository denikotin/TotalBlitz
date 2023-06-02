using System.IO;
using System.Text;
using Assets.Scripts.Data.PlayerData;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class SaveLoadService:IService
    {
        private string _path = $"{Application.dataPath}/save.json";
        private RecordService _recordService;

        public SaveLoadService() => _recordService = Bootstrap.ServiceLocator.GetService<RecordService>();

        public PlayerRecord Load()
        {
            if (!File.Exists(_path)) { return null; }

            string json;
            using (FileStream fs = File.OpenRead(_path))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                json = Encoding.Default.GetString(buffer);
            }

            return JsonConvert.DeserializeObject<PlayerRecord>(json);
        }

        public void Save()
        {
            PlayerRecord playerRecord = _recordService.GetRecord();
            string json = JsonConvert.SerializeObject(playerRecord);

            using (FileStream fs = new FileStream(_path, FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(json);
                fs.Write(buffer,0,buffer.Length);
            }
        }
    }
}
