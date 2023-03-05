using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("Choice");
    }

    public void OnClickHelp()
    {
        SceneManager.LoadScene("Help");
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("Start");
    }
}