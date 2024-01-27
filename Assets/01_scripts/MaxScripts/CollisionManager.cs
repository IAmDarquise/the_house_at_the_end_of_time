using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionManager : MonoBehaviour
{
    public UnityEvent onHit;
    public string colTag;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag(colTag))
            onHit?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.CompareTag(colTag))
            onHit?.Invoke();
    }
}
