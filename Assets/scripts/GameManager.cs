using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text highscoretext;
    public Text scoreText;
    float score;
    int highscore;
 
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
      
    }

    // Update is called once per frame
    void Update()
    {
        
        score += Time.deltaTime *1;
        highscore = (int)score;
        scoreText.text =highscore.ToString();
        if (PlayerPrefs.GetInt("score") <= highscore)
        {
            PlayerPrefs.SetInt("score", highscore);
        }
       
        
    }
    public void highscorefun()
    {
        highscoretext.text = PlayerPrefs.GetInt("score").ToString();
    }
}
