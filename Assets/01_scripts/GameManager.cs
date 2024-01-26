using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public bool finishedRoom;
    public List<GameObject> Collectables = new List<GameObject>();
    public GameObject[] Notes;
    private int noteIndex;

    private GameObject _activeNote;
    void Start()
    {
        Instance= (Instance == null) ? this : Instance;
    }

    public void AddCollectable(GameObject collectable)
    {
        Collectables.Add(collectable);
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
        }
    }
}
