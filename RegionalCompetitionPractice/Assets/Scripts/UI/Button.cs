using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject menu;
    public GameObject help;
    public SaveManager manager;
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickChoice()
    {
        SceneManager.LoadScene("Choice");
    }

    public void OnClickHelp()
    {
        help.SetActive(true);
        menu.SetActive(false);
    }

    public void OnClickBack()
    {
        help.SetActive(false);
        menu.SetActive(true);
    }

    public void OnClickR()
    {
        manager.spriteColor = 0;
    }
    public void OnClickG()
    {
        manager.spriteColor = 1;
    }
    public void OnClickB()
    {
        manager.spriteColor = 2;
    }
    public void OnClickDifE()
    {
        manager.difficulty = 1f;
    }
    public void OnClickDifN()
    {
        manager.difficulty = 2f;
    }
    public void OnClickDifH()
    {
        manager.difficulty = 3f;
    }

    public void OnClickStage()
    {
        if(manager.difficulty != -1 && manager.spriteColor != -1)
        {
            SceneManager.LoadScene("Stage");
        }
    }
}