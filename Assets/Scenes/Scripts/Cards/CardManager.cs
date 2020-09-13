using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "CardManager", menuName = "ScriptableObjects/CardManager", order = 1)]
public class CardManager : ScriptableObject
{
    public CardData[] mCards;
    public float[] chance;
}
