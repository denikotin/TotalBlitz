using Assets.Scripts.Data.PlayerData;

namespace Assets.Scripts.Services
{
    public class RecordService:IService
    {
        private PlayerRecord _playerRecords;

        public PlayerRecord GetRecord() => _playerRecords;
        public void SetPlayerRecord(PlayerRecord playerRecord) => _playerRecords = playerRecord;

        public void WriteRecord(Record record)
        {

            if (_playerRecords.Records.Count == 0)
                _playerRecords.Records.Add(record);

            SortArray();

            for (int i = 0; i < _playerRecords.Records.Count; i++)
            {
                if (record.Value == _playerRecords.Records[i].Value)
                {
                    return;
                }
                else if (record.Value > _playerRecords.Records[i].Value)
                {
                    _playerRecords.Records.Add(record);
                    return;
                }
            }

            SortArray();

            if (_playerRecords.Records.Count > 10)
                _playerRecords.Records.RemoveAt(_playerRecords.Records.Count - 1);
        }

        private void SortArray()
        {
            _playerRecords.Records.Sort((x, y) => x.Value.CompareTo(y.Value));
            _playerRecords.Records.Reverse();
        }
    }
}
