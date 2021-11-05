using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class events : MonoBehaviour
{
    public void replaygame()
    {
        SceneManager.LoadScene("Level");

    }
     public void quitgame()
    {
        Application.Quit();
    }
}
