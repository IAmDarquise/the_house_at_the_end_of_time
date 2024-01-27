using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GameObject collectableInside;
    public bool canBreak = false;

    public Vector3 offset;
    public void Drop()
    {
        canBreak = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
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
            Instantiate(collectableInside, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
