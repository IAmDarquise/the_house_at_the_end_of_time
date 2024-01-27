using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RoomHappyeffect : MonoBehaviour
{
    public SetShaderProp player;
    public SetShaderProp room;
    public string propertyName;
    public float increaseamount;
    public bool active;
    Material mat;
    public float maxsize = 40;
    //bool firsttime;
    //float startsize;
    //new Renderer renderer;



    private void Start()
    {
        mat = this.GetComponent<Renderer>().material;
        player.materials.Add(mat);
        //renderer = GetComponent<Renderer>();
        //room.enabled = false;
    }
    void RoomCompletevfx()
    {
        increaseamount += increaseamount * Time.deltaTime;
        player.enabled = false;
        enabled = true;
        //room.propertyName = propertyName;
        
        mat.SetFloat(propertyName, increaseamount);
        if (increaseamount > maxsize)
        {
            player.enabled = true;
           enabled = false;
           // room.mat = room.mat2;
           //room.mat 
            //room.mat.SetFloat(propertyName, startsize);
        }
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    void Update()
    {
        if (active)
        {
            //if (firsttime)
            //{
            //    startsize = room.mat.GetFloat(propertyName);
            //    ree = false;
            //}
            RoomCompletevfx();

        }

        //else
        //{
        //    ree = true;
        //}
    }
}
