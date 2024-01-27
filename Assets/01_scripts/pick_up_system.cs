using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up_system : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;

    private bool istouched;
    private bool _pickingUp;
    public ObjectTouchDetector detector;


    private void Start()
    {
        detector = GetComponent<ObjectTouchDetector>();
    }


    // Update is called once per frame
    void Update()
    {

        istouched = detector.IsTouched();

        if(istouched && Input.GetMouseButton(0)) 
        {
            if (_pickingUp == false)
            {
                detector.pickedUpObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                detector.pickedUpObject.GetComponent<Collider2D>().isTrigger = true;

                if (detector.pickedUpObject.GetComponent<Breakable>())
                {
                    Breakable breakable =detector.pickedUpObject.GetComponent<Breakable>();
                    
                    offset = breakable.offset;
                }
            }

            _pickingUp = true;
            detector.pickedUpObject.position = player.transform.position + offset;
        }

        if (istouched && Input.GetMouseButtonUp(0))
        {
            detector.pickedUpObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            _pickingUp = false;
            detector.pickedUpObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private IEnumerator CarryObject()
    {
        yield return null;
    }
}
