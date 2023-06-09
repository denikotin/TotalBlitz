﻿using Assets.Scripts.Logic.Camera;
using Assets.Scripts.Services;
using System;
using UnityEngine;

namespace Assets.Scripts.Logic.Player
{
    public class PlayerLose:MonoBehaviour
    {
        private PlayerCollision _playerCollision;
        private MoveController _moveController;
        private CameraController _cameraController;

        public event Action OnPlayerLoseEvent;

        public void Awake()
        {
            _playerCollision = GetComponent<PlayerCollision>();
            _moveController = GetComponent<MoveController>();
            _cameraController = GetComponentInChildren<CameraController>();
        }

        private void OnEnable() => _playerCollision.OnEnemyCollisionEvent += LoseGame;
        private void OnDisable() => _playerCollision.OnEnemyCollisionEvent -= LoseGame;

        private void LoseGame()
        {
           _moveController.enabled = false;
           _cameraController.enabled = false;

            OnPlayerLoseEvent?.Invoke();
        }


    }
}
