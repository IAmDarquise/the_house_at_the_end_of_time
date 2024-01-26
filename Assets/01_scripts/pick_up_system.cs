using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up_system : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;

    private bool istouched;
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
            detector.pickedUpObject.position = player.transform.position + offset;
        } 
       
        // istouched = false;
        
        
        
    }
}
