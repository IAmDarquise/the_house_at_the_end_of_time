using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DroneController : MonoBehaviour
{
    public Rigidbody2D drone;
    public DroneActivate act;
    public bool isGrounded = false;
    public float speed;

    public UnityEvent finishedEvent;
    void Update()
    {
        float x =Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        drone.AddForce(new Vector2(x, y).normalized*speed);
    }


    public void Completed()
    {
        act.active = false;
        act.notcompleted = false;
        finishedEvent?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision) // win condtion Wip
    {
        //Debug.Log(collision.gameObject.tag); 
        if (collision.gameObject.tag == "Finish")
        {
            Completed();
        }
    }
    //private void OnTriggerEnter2D(Collision2D collision)
    //{
    //   
    //}
    //private void Disable()
    //{
    //    act.active = false;
    //}
}
