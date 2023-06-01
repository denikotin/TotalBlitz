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
                case "Coin":
                    Destroy(collision.gameObject);
                    OnCoinCollisionEvent?.Invoke();
                    break;

                case "Enemy":
                    OnEmemyCollisionEvent?.Invoke();
                    break;
            }
        }
    }
}
