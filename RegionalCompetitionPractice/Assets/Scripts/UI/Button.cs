using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject setting;
    public GameObject menu;
    public GameObject help;
    public GameObject rank;

    public bool On = false;
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickChoice()
    {
        SceneManager.LoadScene("Choice");
    }
    public void OnClickMenuScene()
    {
        SceneManager.LoadScene("Start");
    }
    public void OnClickHelp()
    {
        help.SetActive(true);
        menu.SetActive(false);
        rank.SetActive(false);
    }

    public void OnClickMenu()
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
        Player.difficulty = 0.8f;
    }
    public void OnClickDifN()
    {
        Player.difficulty = 1f;
    }
    public void OnClickDifH()
    {
        Player.difficulty = 1.2f;
    }

    public void OnClickRankUpload()
    {
        FindObjectOfType<Rank>().Upload();
    }
    public void OnClickStage()
    {
        if(Player.difficulty != -1 && Player.spriteColor != -1)
        {
            SceneManager.LoadScene("Stage");
        }
    }

    public void OnClickSetting()
    {
        if(!On)
        {
            On = true;
            Time.timeScale = 0;
            setting.SetActive(true);
        }
        else
        {
            On = false;
            Time.timeScale = 1;
            setting.SetActive(false);
        }
    }
}