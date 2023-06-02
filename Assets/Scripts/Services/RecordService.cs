using Assets.Scripts.Data.PlayerData;

namespace Assets.Scripts.Services
{
    public class RecordService:IService
    {
        private PlayerRecord _playerRecords;
        private SaveLoadService _saveLoadService;

        public PlayerRecord GetRecord() => _playerRecords;
        public void SetPlayerRecord(PlayerRecord playerRecord) => _playerRecords = playerRecord;

        public void WriteRecord(Record record)
        {
            _playerRecords.Records.Add(record);
            //if (record.Value > _playerRecords.Records[0].Value)
            //{
            //    _playerRecords.Records.Insert(0, record);
            //}
            //if (_playerRecords.Records.Count > 10)
            //{
            //    _playerRecords.Records.RemoveAt(_playerRecords.Records.Count);
            //}
        }
    }
}
