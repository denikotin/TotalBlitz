using System;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class PlayerCollision:MonoBehaviour
    {
        public event Action OnCoinCollisionEvent;
        public event Action OnEmemyCollisionEvent;


        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.transform.tag);
            switch (collision.transform.tag)
            {
                case "Enemy":
                    OnEmemyCollisionEvent?.Invoke();
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
