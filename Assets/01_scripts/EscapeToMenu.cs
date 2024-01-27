using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToMenu : MonoBehaviour
{
    public string gobacktomenu;

    public void GoBackToMenuWithEscape()
    {
        SceneManager.LoadScene(gobacktomenu);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBackToMenuWithEscape();
        }
    }

}
