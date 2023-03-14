using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillUI : MonoBehaviour
{
    public Player player;

    public Text skill1Text;
    public Text skill2Text;
    public Text NoSkill1Text;
    public Text NoSkill2Text;

    void Update()
    {
        skill1Text.text = string.Format("{0}", player.skill1Time > 10 ? player.skill1Count : 10 - (int)player.skill1Time);
        skill2Text.text = string.Format("{0}", player.skill2Time > 10 ? player.skill2Count : 10 - (int)player.skill2Time);
    }

    public void NoSkill1()
    {
        NoSkill1Text.gameObject.SetActive(true);
        Invoke("FillText1", 1f);
    }

    void FillText1()
    {
        NoSkill1Text.gameObject.SetActive(false);
    }

    public void NoSkill2()
    {
        NoSkill2Text.gameObject.SetActive(true);
        Invoke("FillText2", 1f);
    }

    void FillText2()
    {
        NoSkill2Text.gameObject.SetActive(false);
    }
}