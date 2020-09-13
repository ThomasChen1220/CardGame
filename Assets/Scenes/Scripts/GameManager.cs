using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int finalDamage;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadOnePunchScene(int damage) {
        finalDamage = damage;
        SceneManager.LoadScene("OnePunchScene");
    }
}
