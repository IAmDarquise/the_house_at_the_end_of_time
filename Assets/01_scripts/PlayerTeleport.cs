using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Transform[] teleportDestinations;
    private int currentDestinationIndex = 0;
    private Transform lastTeleportDestination;

    public void TeleportPlayer()
    {
        if(GameManager.Instance.finishedRoom)
            if(teleportDestinations != null && teleportDestinations.Length > 0)
            {
                transform.position = teleportDestinations[currentDestinationIndex].position;

                lastTeleportDestination = teleportDestinations[currentDestinationIndex];

                Debug.Log("Player teleported to destination " + currentDestinationIndex);

                if(currentDestinationIndex > teleportDestinations.Length)
                    return;
                //currentDestinationIndex = (currentDestinationIndex + 1) % teleportDestinations.Length;
                currentDestinationIndex++;

                GameManager.Instance.finishedRoom = false;
            }
            else
            {
                Debug.Log("Teleport destinations are not set!");
            }
    }

    public void RespawnPlayer()
    {
        
        if (lastTeleportDestination != null)
        {
            transform.position = lastTeleportDestination.position;
            Debug.Log("Player respawned at the last teleport destination");
        }
        else
        {
            Debug.LogError("No last teleport destination set for respawn!");
        }
    }
    


}
