using System;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class EnemyInputService : IInputService
    {
        public Axis GetDirection()
        {
            return new Axis();
        }

        public Quaternion GetRotation()
        {
            return new Quaternion();
        }
    }
}
