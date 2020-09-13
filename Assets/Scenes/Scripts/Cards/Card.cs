using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Card : MonoBehaviour
{
    public static PlayerStatus mPlayer;
    public static UIManager mUI;
    public CardData data;
    public CardManager cardManager;
    public CardGallery mGallery;

    void LoadCardData() {
        transform.Find("Background").GetComponent<Image>().color = data.background;
        transform.Find("Icon").GetComponent<Image>().sprite = data.icon;
        transform.Find("Icon").GetComponent<Image>().color = data.iconColor;
        transform.Find("Description").GetComponent<Text>().text = data.description;
        transform.Find("Name").GetComponent<Text>().text = data.mName;
    }
    private void Awake()
    {
        if(mPlayer==null)
            mPlayer = GameObject.Find("Player").GetComponent<PlayerStatus>();
        if (mUI == null)
            mUI = GameObject.Find("UIManager").GetComponent<UIManager>();

        LoadCardData();
    }
    public void RevealCard()
    {
        if (!mGallery.revealed)
        {
            mGallery.revealed = true;
            transform.Find("Description").GetComponent<Text>().DOColor(new Color(0, 0, 0, 0), 0.5f).onComplete = ShowEffectText;
            transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.8f).SetEase(mGallery.cardEase);
        }
    }
    private void ShowEffectText() {
        transform.Find("Description").GetComponent<Text>().text = data.effect;
        transform.Find("Description").GetComponent<Text>().DOColor(Color.black, 1f);
    }
    public void GetRandomCard() {
        float total = 0;
        for(int i = 0; i < cardManager.chance.Length; i++)
        {
            total += cardManager.chance[i];
        }
        float val = Random.Range(0, total);
        int index = 0;
        for(int i=0; i < cardManager.chance.Length; i++)
        {
            val -= cardManager.chance[i];
            if (val <= 0)
            {
                index = i;
                break;
            }
        }
        data = cardManager.mCards[index];
        LoadCardData();
    }
    private void Update()
    {
    }
    public void DoEffect() {
        if (mGallery.revealed) return;
        mPlayer.attack += data.attackIncrease;
        mPlayer.hp += data.healthIncrease;
        mPlayer.defense += data.defIncrease;
        mPlayer.crit += data.critIncrease;

        int amount = 0;
        if (data.from == CardData.StatType.Health)
        {
            amount = mPlayer.hp;
            mPlayer.hp = 0;
        }
        else if(data.from == CardData.StatType.Defense)
        {
            amount = mPlayer.defense;
            mPlayer.defense = 0;
        }
        if(data.to == CardData.StatType.Attack)
        {
            mPlayer.attack += amount;
            amount = 0;
        }
        else if(data.to == CardData.StatType.Crit) {
            mPlayer.crit += amount;
            amount = 0;
        }
        mUI.UpdatePlayerStatus();
    }
}
