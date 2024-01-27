using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipToMainMenu : MonoBehaviour
{
    public string skiptomenu;

    public void SkipToMenuWithEscape()
    {
        SceneManager.LoadScene(skiptomenu);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SkipToMenuWithEscape();
        }
    }
}
