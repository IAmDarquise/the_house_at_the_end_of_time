using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    private Transform _hands;
    private Transform _heldItem;


    private void Pickup(Transform pickupObj)
    {
        pickupObj.parent = _hands;
    }
}
