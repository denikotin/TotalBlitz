using System;
using UnityEngine;

public class AggroTrigger : MonoBehaviour
{
    public event Action OnPlayerTriggerEnter;
    public event Action OnPlayerTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerTriggerEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerTriggerExit?.Invoke();
        }
    }
}
