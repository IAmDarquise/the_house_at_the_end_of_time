using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public Slider slider;
    public AudioManager a;
    void Start()
    {
        slider.onValueChanged.AddListener(a.SetVolume);

    }

   
}
