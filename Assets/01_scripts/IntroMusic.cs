using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMusic : MonoBehaviour
{
    public AudioSource au;
    public float starttime;
    public float endtime;
    public float fadestep = 0.025f;
    public SkipToMainMenu es;


    // Start is called before the first frame update
    void Start()
    {
        au.time = starttime;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(au.time);

        if (au.time > endtime-4)
        {
            au.volume -= fadestep * Time.deltaTime;

            if (au.time > endtime)
            {
                es.SkipToMenuWithEscape();
            }
        }
    }
}
