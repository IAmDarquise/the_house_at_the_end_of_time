using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    

    public void GoBackToMenuWithEscape()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GoBackToMenuWithEscape();
        }
    }
}
