using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Transform[] teleportDestinations;
    private int currentDestinationIndex = 0;

    public void TeleportPlayer()
    {
        if(teleportDestinations != null && teleportDestinations.Length > 0)
        {
            transform.position = teleportDestinations[currentDestinationIndex].position;

            Debug.Log("Player teleported to destination " + currentDestinationIndex);

            currentDestinationIndex = (currentDestinationIndex + 1) % teleportDestinations.Length;
        }
        else
        {
            Debug.Log("Teleport destinations are not set!");
        }
    }
}
