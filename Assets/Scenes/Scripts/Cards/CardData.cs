using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData : ScriptableObject
{
    public Sprite icon;
    public Color iconColor;
    public Color background;
    public string mName;
    [TextArea (1,3)]
    public string description, effect;

    [Header ("Effect")]
    public int attackIncrease = 0;
    public float attackMulti = 1;
    public int healthIncrease = 0;
    public float healthMulti = 1;
    public int defIncrease = 0;
    public float defMulti = 1;
    public int critIncrease = 0;
    public float critMulti = 1;
    
    public enum StatType { None, Health, Attack, Defense, Crit }
    [Header("Trade")]
    public StatType from;
    public StatType to;
    public float amount;
    public float multi;
}
