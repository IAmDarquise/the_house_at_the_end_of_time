using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AnimController : MonoBehaviour
{
    public UnityEvent animEvent;
    public string nextscene;

    public void AnimEvent()
    {
        animEvent.Invoke();
    }

    void NextScene()
    {
        SceneManager.LoadScene(nextscene);
    }
}
