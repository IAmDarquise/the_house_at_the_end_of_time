using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public PlayerTeleport playerTeleport;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Player"))
        {
            playerTeleport.TeleportPlayer();
        }
    }
}
