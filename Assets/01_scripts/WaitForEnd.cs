using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForEnd : MonoBehaviour
{
    public float delay;
    public EndScript end;

    public PlayerMovement p;
    // Start is called before the first frame update
    public void DoIt()
    {
        //p.speed = 0;
        //p.transform.position = new Vector3(4, p.transform.position.y, p.transform.position.z);
        StartCoroutine(StartEndIn());
    }

    IEnumerator StartEndIn()
    {
        yield return new WaitForSeconds(delay);
        end.enabled = true;
        StopCoroutine(StartEndIn());
    }
}
