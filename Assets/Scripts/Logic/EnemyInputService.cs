using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class EnemyInputService : IInputService
    {
        private Transform _player;
        private Transform _enemy;

        public EnemyInputService(Transform enemy,Transform player) 
        {
            _player = player;
            _enemy = enemy;
        }

        public Axis GetDirection()
        {
            Vector3 dir = _player.position - _enemy.position;
            return new Axis(dir.x,dir.z);
        }

        public Quaternion GetRotation()
        {
            return Quaternion.identity;
        }
    }
}
