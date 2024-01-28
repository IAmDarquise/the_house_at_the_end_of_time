using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityController : MonoBehaviour
{
   public float delay;
   public float time;
    public Material mat;
    public SpriteRenderer spr;

   private void Awake()
   {
      
   }
    public void Update()
    {
        mat.color = spr.color;

    }
}
