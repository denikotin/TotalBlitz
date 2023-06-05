using System;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class EnemyInputService:MonoBehaviour
    {
        [SerializeField] MoveController _moveController;
        [SerializeField] CharacterRaycast _characterRaycast;
        [SerializeField] AggroTrigger _aggroTrigger;
     
        private Transform _player;


        private void OnEnable()
        {
            _aggroTrigger.OnPlayerTriggerEnter += FollowPlayer;
            _aggroTrigger.OnPlayerTriggerExit += StopFollowPlayer;
        }


        private void OnDisable()
        {
            _aggroTrigger.OnPlayerTriggerEnter -= FollowPlayer;
            _aggroTrigger.OnPlayerTriggerExit -= StopFollowPlayer;
        }

        public void Construct(Transform player)
        {
            _player = player;
        }

        public void Update()
        {
            Move();
        }

        public void Move()
        {
            _moveController.MoveForward();
            if (_characterRaycast.IsWallForward)
            {
                _moveController.Stop();
                if (_characterRaycast.IsWallLeft)
                {
                    _moveController.Turn(1);
                    return;
                }
                else if (_characterRaycast.IsWallRight)
                {
                    _moveController.Turn(-1);
                    return;
                }
                _moveController.Turn(-1);
            }
            else if (_characterRaycast.IsWallLeft)
            {
                _moveController.Turn(1);
                return;
            }
            else if(_characterRaycast.IsWallRight)
            {
                _moveController.Turn(-1);
                return;
            }
        }



        private void FollowPlayer()
        {
            Vector3 target = _player.transform.position - transform.position;
        }

        private void StopFollowPlayer()
        {

        }

    }
}
