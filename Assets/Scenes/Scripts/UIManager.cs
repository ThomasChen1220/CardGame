using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerStatus playerStatus;//drag the gameObject with PlayerStatus script/OPTIONALscriptableobject/ singleclass
    
    public Text hpText, attackText, defenseText, critText, damageText;

    public Animator[] gameObjectWithAnimators;
    public Text hpDisplayText, attDisplayText, defDisplayText, critDisplayText, damageDisplayText;
    public Text date;
    public int dayNumber = 0;
    
    string GetWithSign(int amount)
    {
        if (amount > 0)
        {
            return "+" + amount;
        }
        else
        {
            return "" + amount;
        }
    }
    public void MakingAnimation()
    {
        playerStatus.UpdateDamage();
        hpDisplayText.text = GetWithSign(playerStatus.hp - playerStatus.preHp);
        attDisplayText.text = GetWithSign(playerStatus.attack - playerStatus.preAtt);
        defDisplayText.text = GetWithSign(playerStatus.defense - playerStatus.preDef);
        critDisplayText.text = GetWithSign(playerStatus.crit - playerStatus.preCrit);
        damageDisplayText.text = GetWithSign(playerStatus.damage - playerStatus.preDam);

        if ((playerStatus.hp - playerStatus.preHp) != 0)
        {
            gameObjectWithAnimators[0].SetTrigger("Levelup");
        }
        if ((playerStatus.attack - playerStatus.preAtt) != 0)
        {
            gameObjectWithAnimators[1].SetTrigger("Levelup");
        }
        if ((playerStatus.defense - playerStatus.preDef) != 0)
        {
            gameObjectWithAnimators[2].SetTrigger("Levelup");
        }
        if ((playerStatus.crit - playerStatus.preCrit) != 0)
        {
            gameObjectWithAnimators[3].SetTrigger("Levelup");
        }
        if ((playerStatus.damage - playerStatus.preDam) != 0)
        {
            gameObjectWithAnimators[4].SetTrigger("Levelup");
        }
        playerStatus.UpdatePrev();

    }

    private void Start()
    {
        UpdatePlayerStatus();

    }
    public void UpdatePlayerStatus() 
    {
        MakingAnimation();  
        hpText.text = "" + playerStatus.hp;
        attackText.text = "" + playerStatus.attack;
        defenseText.text = "" + playerStatus.defense;
        critText.text = "" + playerStatus.crit + "%";
        damageText.text = "" + playerStatus.damage;
        date.text = "Day" + ++dayNumber;
    }


}
