using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
