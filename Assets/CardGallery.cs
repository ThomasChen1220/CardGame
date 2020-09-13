using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardGallery : MonoBehaviour
{
    public bool revealed=false;
    bool inAnim = false;
    public Ease cardEase;

    private void Start()
    {
        RefreshCards();
    }
    public void RefreshCards()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            transform.GetChild(i).DOScale(new Vector3(1, 1, 1), 1f).SetEase(cardEase);
            transform.GetChild(i).GetComponent<Card>().GetRandomCard();
        }
        transform.GetChild(0).DOScale(new Vector3(1, 1, 1), 1f).SetEase(cardEase).onComplete = ResetBools;
        transform.GetChild(0).GetComponent<Card>().GetRandomCard();

        revealed = false;
    }
    public void ResetBools() {
        inAnim = false;
    }
    private void Update()
    {
        if (revealed && Input.GetMouseButtonDown(0) && !inAnim)
        {
            inAnim = true;
            for (int i = 1; i < transform.childCount; i++)
            {
                transform.GetChild(i).DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.9f).SetEase(cardEase);
            }
            transform.GetChild(0).DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.9f).SetEase(cardEase).onComplete = RefreshCards;
        }
    }
}
