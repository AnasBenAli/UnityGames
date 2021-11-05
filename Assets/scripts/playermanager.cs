using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class playermanager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanal;
    public static bool isgamestarted;
    public GameObject startingtext;
    public static int numberOfCoins;
    public Text coinstext;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isgamestarted = false;
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanal.SetActive(true);
        }
        coinstext.text = "Coins: " + numberOfCoins;
        if (swipemanager.tap)
        {
            isgamestarted = true;
            Destroy(startingtext);
        }
    }
}
