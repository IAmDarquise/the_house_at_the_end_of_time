using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrashObject : MonoBehaviour
{
    public float neededVelocity;

    public UnityEvent onBreak;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("MovableObject"))
        {
            var relativeVelocity = col.transform.GetComponent<Rigidbody2D>().velocity.magnitude;
            Debug.Log(relativeVelocity);

            if (relativeVelocity >= neededVelocity)
            {
                Debug.Log("knock");
                onBreak?.Invoke();
            }
        }
            
    }
}
