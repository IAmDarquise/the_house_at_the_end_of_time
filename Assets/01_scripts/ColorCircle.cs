using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCircle : MonoBehaviour
{
    public RectTransform rectTransform;


    // Update is called once per frame
    void Update()
    {
        rectTransform.position = Input.mousePosition;
    }
}
