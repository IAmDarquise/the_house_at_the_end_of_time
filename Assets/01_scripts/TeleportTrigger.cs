using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportTrigger : MonoBehaviour
{
    public PlayerTeleport playerTeleport;

    public UnityEvent onTeleport;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.finishedRoom)
            {
                playerTeleport.TeleportPlayer();
                onTeleport?.Invoke();
                GameManager.Instance.SwapOutsides();
            }
        }
    }
}
