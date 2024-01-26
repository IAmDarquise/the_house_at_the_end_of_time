using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_player_movement_pascal : MonoBehaviour
{
    public float moveSpeed = 5f;



    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);


    }
}
