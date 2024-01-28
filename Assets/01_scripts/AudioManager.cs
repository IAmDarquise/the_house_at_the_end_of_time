using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    [Range(0f, 1f)]
    public float volume;
   // public Slider slider;
    void Start()
    {
        ////slider.onValueChanged.AddListener(SetVolume);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += FindAudioManager;

        //audioSource.time = Random.Range(0, audioSource.clip.length/2); <- no
    }


    public void SetVolume(float vol)
    {
        audioSource.volume = vol;
    }

    public void FindAudioManager(Scene scene, LoadSceneMode mode)
    {
        GameObject.Find("AudioManager");
    }
}
