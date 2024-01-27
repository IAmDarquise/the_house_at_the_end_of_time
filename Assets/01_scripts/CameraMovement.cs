using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    Vector2 dist;
    public float speed;
    public Vector3 offset;

    // Start is called before the first frame update
    void Update()
    {
        
        dist = new Vector2((player.position.x - transform.position.x)+offset.x,(player.position.y - transform.position.y)+ offset.y);
        //if (dist.x < 0.01) transform.position = new Vector3(player.transform.position.x,transform.position.y, transform.position.z);
        //if (dist.y < 0.01 ) transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x + dist.x * speed * Time.deltaTime, transform.position.y + dist.y *speed * Time.deltaTime, transform.position.z);
        
    }

 
    
}
