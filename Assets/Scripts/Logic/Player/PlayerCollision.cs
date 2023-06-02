using System;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class PlayerCollision:MonoBehaviour
    {
        public event Action OnCoinCollisionEvent;
        public event Action OnEnemyCollisionEvent;


        private void OnCollisionEnter(Collision collision)
        {
            switch (collision.transform.tag)
            {
                case "Enemy":
                    OnEnemyCollisionEvent?.Invoke();
                    break;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.gameObject.tag)
            {
                case "Coin":
                    Destroy(other.gameObject);
                    OnCoinCollisionEvent?.Invoke();
                    break;
            }
        }
    }
}
