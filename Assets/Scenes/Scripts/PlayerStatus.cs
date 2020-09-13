using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public UIManager uiManger;
    #region
    public int hp, attack, defense, crit;
    [HideInInspector]
    public int damage;
    #endregion
    
    [HideInInspector]
    public int preHp, preAtt, preDef, preCrit, preDam;
    
    private void Start()
    {
        preHp = hp;
        preAtt = attack;
        preDef = defense;
        preCrit = crit;
    }
    public void UpdatePrev() {
        preHp = hp;
        preAtt = attack;
        preDef = defense;
        preCrit = crit;
        preDam = damage;
    }
    public void UpdateDamage() {
        damage = (int)(attack * (1.0f*crit / 100));
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            uiManger.UpdatePlayerStatus();
        }
    }


}
