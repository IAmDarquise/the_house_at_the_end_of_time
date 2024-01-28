using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    public bool isVase;
    public GameObject collectableInside;
    public bool canBreak = false;

    public UnityEvent onSetBreak;
    public UnityEvent onBreak;
    public Vector3 offset;

    public Transform spawnPos;
    public void Drop()
    {
        canBreak = true;
        onSetBreak?.Invoke();
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.transform.CompareTag("Ground"))
        {
            Break();
        }
    }

    private void Break()
    {
        if (canBreak)
        {
            Instantiate(collectableInside, spawnPos.position, Quaternion.identity);
            onBreak?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.CompareTag("Break"))
            Drop();
    }
}
