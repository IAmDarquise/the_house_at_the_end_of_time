using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NextLevel"))
        {
            if (GameManager.Instance.finishedRoom)
            {
                //go to next room
                //Camera jump animation
                //set sprites as inactive
            }

        }
    }
}
