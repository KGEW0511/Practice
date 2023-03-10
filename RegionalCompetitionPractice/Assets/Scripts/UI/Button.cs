using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject menu;
    public GameObject help;
    public GameObject rank;
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickChoice()
    {
        SceneManager.LoadScene("Choice");
    }

    public void OnClickMenu()
    {
        Debug.Log("이기운지");
        SceneManager.LoadScene("Start");
    }
    public void OnClickHelp()
    {
        help.SetActive(true);
        menu.SetActive(false);
        rank.SetActive(false);
    }

    public void OnClickBack()
    {
        help.SetActive(false);
        menu.SetActive(true);
        rank.SetActive(false);
    }

    public void OnClickRank()
    {
        help.SetActive(false);
        menu.SetActive(false);
        rank.SetActive(true);
    }

    public void OnClickR()
    {
        Player.spriteColor = 0;
    }
    public void OnClickG()
    {
        Player.spriteColor = 1;
    }
    public void OnClickB()
    {
        Player.spriteColor = 2;
    }
    public void OnClickDifE()
    {
        Player.difficulty = 1f;
    }
    public void OnClickDifN()
    {
        Player.difficulty = 2f;
    }
    public void OnClickDifH()
    {
        Player.difficulty = 3f;
    }

    public void OnClickStage()
    {
        if(Player.difficulty != -1 && Player.spriteColor != -1)
        {
            SceneManager.LoadScene("Stage");
        }
    }
}