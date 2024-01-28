using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string goscene_credit;
    public string goscene_start;
    public string goscene_howto;

    public void StartGame()
    {
        SceneManager.LoadScene(goscene_start);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene(goscene_credit);
    }

    public void HowTo()
    {
        SceneManager.LoadScene(goscene_howto);
    }

}
