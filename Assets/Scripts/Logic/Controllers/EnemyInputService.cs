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

        private bool _isFollow = false;
       


        private void OnEnable()
        {
            _aggroTrigger.OnPlayerTriggerEnter += StartFollow;
            _aggroTrigger.OnPlayerTriggerExit += StopFollow;
        }


        private void OnDisable()
        {
            _aggroTrigger.OnPlayerTriggerEnter -= StartFollow;
            _aggroTrigger.OnPlayerTriggerExit -= StopFollow;
        }

        public void Construct(Transform player)
        {
            _player = player;
        }

        public void Update()
        {
            if (!_isFollow)
            {
                Patrol();
            }
            else
            {
                FollowPlayer();
            }
        }

        public void Patrol()
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


        private void StartFollow() => _isFollow = true;

        private void StopFollow() => _isFollow = false;

        private void FollowPlayer()
        {
            Vector3 target = _player.transform.position - transform.position;
            _moveController.MoveToDirection(target);
        }
    }
}
