using System;

namespace Assets.Scripts.Data.PlayerData
{
    [Serializable]
    public class Record
    {
        public int Value;

        public Record(int value)
        {
            Value = value;
        }
    }
}
