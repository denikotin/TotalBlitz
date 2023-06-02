using System;
using System.Collections.Generic;

namespace Assets.Scripts.Data.PlayerData
{
    [Serializable]
    public class PlayerRecord
    {
        public List<Record> Records;
        public PlayerRecord() => Records = new List<Record>();
    }
}
