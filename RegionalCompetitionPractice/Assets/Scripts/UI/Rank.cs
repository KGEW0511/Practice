using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    public Text rank1;
    public Text rank2;
    public Text rank3;
    public Text rank4;
    public Text rank5;

    int curS;
    int tempS;
    static int[] score = new int[5];

    string curN;
    string tempN;
    static string[] name = new string[5];

    void Update()
    {
        rank1.text = "1. " + name[0] + string.Format(" Score : {0} ", score[0]);
        rank2.text = "2. " + name[1] + string.Format(" Score : {0} ", score[1]);
        rank3.text = "3. " + name[2] + string.Format(" Score : {0} ", score[2]);
        rank4.text = "4. " + name[3] + string.Format(" Score : {0} ", score[3]);
        rank5.text = "5. " + name[4] + string.Format(" Score : {0} ", score[4]);
    }

    void Upload()
    {
        curS = Player.score;
        curN = "¹º°¡ ¹Þ¾Æ¿È";

        if(curS > score[0])
        {
            for (int i = 0; i < 5; i++)
            {
                tempS = curS;
                curS = score[i];
                score[i] = tempS;
            }
        }
        else if (curS > score[1])
        {
            for (int i = 1; i < 5; i++)
            {
                tempS = curS;
                curS = score[i];
                score[i] = tempS;
            }
        }
        else if (curS > score[2])
        {
            for (int i = 2; i < 5; i++)
            {
                tempS = curS;
                curS = score[i];
                score[i] = tempS;
            }
        }
        else if (curS > score[3])
        {
            for (int i = 3; i < 5; i++)
            {
                tempS = curS;
                curS = score[i];
                score[i] = tempS;
            }
        }
        else if (curS > score[4])
        {
            for (int i = 4; i < 5; i++)
            {
                tempS = curS;
                curS = score[i];
                score[i] = tempS;
            }
        }
    }
}
