using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CursorFollow : MonoBehaviour
{
    public Vector2 offset;
    public float zDistance;
    private Vector2 mousePos;

    private Vector3 truePoint;


    private void Awake()
    {
       
        Cursor.visible = false;
    }
    private void Update()
    {
        GetMousePos();
    }
    void GetMousePos()
    {
        mousePos = Input.mousePosition;

        truePoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, zDistance));

        transform.position = mousePos;
    }
}
