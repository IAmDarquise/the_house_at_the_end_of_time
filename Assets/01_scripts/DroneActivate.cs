using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneActivate : MonoBehaviour
{
    public DroneController drone;
    public bool active = false;
    public PlayerMovement player;
    public bool notcompleted = true;
    public CameraMovement cam;
    //float wait = 0;
    //float normalspeed;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (player != null)
            {
                player.enabled = false;
            }
            drone.enabled = true;
            cam.player = this.transform;
        }

        else
        {
            if (player != null)
            {
                player.enabled = true;
            }
            drone.enabled = false;
            cam.player = player.transform;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && notcompleted)
        {
            active = true;
        }
    }

}
