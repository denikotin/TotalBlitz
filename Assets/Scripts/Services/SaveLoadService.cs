using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Data.PlayerData;
using Newtonsoft.Json;

namespace Assets.Scripts.Services
{
    public class SaveLoadService:IService
    {

        public SaveLoadService() 
        {
            _recordService = Bootstrap.ServiceLocator.GetService<RecordService>();
        }

        public void Load()
        {
          
        }

        public void Save()
        {

        }
    }
}
