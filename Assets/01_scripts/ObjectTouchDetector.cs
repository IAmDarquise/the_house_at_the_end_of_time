using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTouchDetector : MonoBehaviour
{
    private bool isTouched = false;
    public Transform pickedUpObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MovableObject"))
        {
            isTouched = true;

            Debug.Log("Object Touched");

            pickedUpObject = other.transform;
        }

        if (other.CompareTag("Collectable"))
        {
            GameObject collect = other.gameObject;
            GameManager.Instance.AddCollectable(other.gameObject);
            //particle system machen
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MovableObject"))
        {
            isTouched = false;

            Debug.Log("Object Touched");

            pickedUpObject = null;
        }
    }


    public bool IsTouched()
    {
        return isTouched;
    }
}
