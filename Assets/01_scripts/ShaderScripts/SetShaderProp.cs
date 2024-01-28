using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShaderProp : MonoBehaviour
{
    public Material mat;
    public string propertyName;
    public Transform player;
    public List<Material> materials;

    // Update is called once per frame
   

    void Update()
    {
        if (player != null)
        {
            foreach (Material mat in materials)
            {
                if (mat != null) { 
                    mat.SetVector(propertyName, player.position);
                }
            }
            
        }
    }
    
}
