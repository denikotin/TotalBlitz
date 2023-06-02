using Assets.Scripts.Data.PlayerData;
using System.Collections.Generic;

namespace Assets.Scripts.Services
{
    public class RecordService:IService
    {
        private PlayerRecord _playerRecords;



        public PlayerRecord GetRecord() => _playerRecords;

        public List<Record> GetRecords() 
        {
            return _playerRecords.Records;
        }

        public void WriteRecord(Record record)
        {
            if (record.Value > _playerRecords.Records[0].Value)
            {
                _playerRecords.Records.Insert(0, record);
            }
            if (_playerRecords.Records.Count > 10)
            {
                _playerRecords.Records.RemoveAt(_playerRecords.Records.Count);
            }
        }
    }
}
