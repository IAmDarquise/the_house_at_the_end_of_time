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

    private GameObject _activeNote;
    void Start()
    {
        Instance= (Instance == null) ? this : Instance;
        
        LockCursor();
    }

    public void AddCollectable(GameObject collectable)
    {
        Collectables.Add(collectable);
        Portals[noteIndex].SetActive(true);
        ShowNote();
        noteIndex++;
    }

    private void ShowNote()
    {
       _activeNote = Instantiate(Notes[noteIndex], GameObject.Find("Canvas").transform);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _activeNote != null)
        {
            Destroy(_activeNote);
            _activeNote = null;
            finishedRoom = true;
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
