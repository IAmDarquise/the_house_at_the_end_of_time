using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShaderProp : MonoBehaviour
{
    public Material mat;
    public string propertyName;
    public Transform player;
    

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            mat.SetVector(propertyName, player.position);
        }
    }
}
