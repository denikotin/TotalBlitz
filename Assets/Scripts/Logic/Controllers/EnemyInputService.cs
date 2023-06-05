using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class EnemyInputService:MonoBehaviour
    {
        [SerializeField] MoveController _moveController;
        private Transform _player;

        public void Construct(Transform player)
        {
            _player = player;
        }

        public EnemyInputService(Transform enemy,Transform player) 
        {
            _player = player;
        }

        public Axis GetDirection()
        {
            Vector3 dir = _player.position - transform.position;
            return new Axis(dir.x,dir.z);
        }

        public Quaternion GetRotation() => Quaternion.identity;
    }
}
