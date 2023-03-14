using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    public InputField rankName;

    public Text playerScore;
    public Text rank1;
    public Text rank2;
    public Text rank3;
    public Text rank4;
    public Text rank5;

    bool isWrite;

    int playerRank;

    float curS;
    float tempS;
    static float[] score = new float[5];

    string curN;
    string tempN;
    static string[] name = new string[5];


    void Awake()
    {
        isWrite = false;
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Finish"){
            playerScore.text = string.Format("Your Score : {0}", Player.score);
        }
        rank1.text = "1. " + name[0] + string.Format(" Score : {0} ", score[0]);
        rank2.text = "2. " + name[1] + string.Format(" Score : {0} ", score[1]);
        rank3.text = "3. " + name[2] + string.Format(" Score : {0} ", score[2]);
        rank4.text = "4. " + name[3] + string.Format(" Score : {0} ", score[3]);
        rank5.text = "5. " + name[4] + string.Format(" Score : {0} ", score[4]);
    }

    public void Upload()
    {
        if (!isWrite)
        {
            isWrite = true;

            curS = Player.score + 3;
            curN = rankName.text;

            for (int i = 0; i < 5; i++)
            {
                if (curS > score[i])
                {
                    RankSys(i);
                    return;
                }
            }
        }
        else
        {
            name[playerRank] = rankName.text;
        }
    }

    void RankSys(int n)
    {
        playerRank = n;
        for (int i = n; i < 5; i++)
        {
            tempS = curS;
            curS = score[i];
            score[i] = tempS;

            tempN = rankName.text;
            rankName.text = name[i];
            name[i] = tempN;
        }
    }
}
