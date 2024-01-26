using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public bool finishedRoom;
    public List<GameObject> Collectables = new List<GameObject>();
    void Start()
    {
        Instance= (Instance == null) ? this : Instance;
    }

    public void AddCollectable(GameObject collectable)
    {
        Collectables.Add(collectable);
    }
}
