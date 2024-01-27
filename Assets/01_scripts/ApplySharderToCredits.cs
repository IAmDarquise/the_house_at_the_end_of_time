using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplySharderToCredits : MonoBehaviour
{
    public Material customMat;
    public Image uiImage;
    public float size;



    // Start is called before the first frame update
    void Start()
    {
        uiImage.material = customMat;
        customMat.SetFloat("_CircleRadius", size);
    }

   
}
