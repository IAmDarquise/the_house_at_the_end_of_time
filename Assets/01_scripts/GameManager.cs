using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int roomNum;
    public static GameManager Instance;
    public bool finishedRoom;
    public GameObject[] outsides;
    public List<GameObject> Collectables = new List<GameObject>();
    public GameObject[] Portals;
    public GameObject[] Notes;
    private int noteIndex;
    int roomid;
    public List<RoomHappyeffect> rooms;
    public PlayerMovement player;
    public Rigidbody2D rigi;
    float speed;
    float wait;
    private GameObject _activeNote;
    void Start()
    {
        Instance= (Instance == null) ? this : Instance;
        speed = player.speed;
        LockCursor();
    }

    public void AddCollectable(GameObject collectable)
    {
        
        rooms[roomid].active = true;
        roomid++;
        Collectables.Add(collectable);
        Portals[noteIndex].SetActive(true);
        ShowNote();
        noteIndex++;
        player.speed = 0;
        wait = 0;
        rigi.velocity = new Vector2(0,0);
    }

    private void ShowNote()
    {
       _activeNote = Instantiate(Notes[noteIndex], GameObject.Find("Canvas").transform);
    }

    private void Update()
    {
        
        if (player.speed == 0)
        {
            wait += Time.deltaTime;
            if (wait >= 3.5f) { 
            player.speed = speed;
            }
        }
        
        if (Input.GetMouseButtonDown(0) && _activeNote != null)
        {
            Destroy(_activeNote);
            _activeNote = null;
            finishedRoom = true;
            wait = 3.5f;
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void SwapOutsides()
    {  
        outsides[roomNum].SetActive(true);
        roomNum++;
        outsides[roomNum].SetActive(false);
    }
}
