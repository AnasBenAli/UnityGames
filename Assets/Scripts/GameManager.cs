using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform pellets;
    public Pacman pacman;
    public Text Score;
    public Transform Ghosts;
    public Ghost[] GS;
    
    public Button pause;
    public bool isPaused { get; set; }
    public int scoreCount { get; set; }

    [Obsolete]
    void Start()
    {
        FreezeGhosts();
        scoreCount = 0;
        isPaused = true;

        pause.onClick.AddListener(() =>
        {
            if (isPaused)
            {
                isPaused = false;
                pause.GetComponentInChildren<Text>(true).text = "Pause";
                UnfreezeGhosts();
            }
            else
            {
                isPaused = true;
                pause.GetComponentInChildren<Text>(true).text = "Play";
                FreezeGhosts();
            }
        });

    }



    [System.Obsolete]
    void Update()
    {
        if (!isPaused)
        {
            Score.text = "Score: " + scoreCount.ToString();
            if (!hasRemainingPellets())
            {
                ResetAllPos();
            }
        }
        else
        {

        }
    }


    [System.Obsolete]
    private void FreezeGhosts()
    {
        for (int i = 0; i < Ghosts.childCount; i++)
        {
            GameObject ghost = Ghosts.GetChild(i).gameObject;
            ghost.GetComponent<NavMesh>().enabled = false;
            ghost.GetComponent<NavMeshAgent>().enabled = false;
        }
    }
    private void UnfreezeGhosts()
    {
        for (int i = 0; i < Ghosts.childCount; i++)
        {
            GameObject ghost = Ghosts.GetChild(i).gameObject;
            ghost.GetComponent<NavMesh>().enabled = true;
            ghost.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
    public void reset()
    {
        this.pacman.transform.position = this.pacman.intiPos;
        this.pacman.gameObject.SetActive(true);
    }
    bool hasRemainingPellets()
    {
        for (int i = 0; i < pellets.childCount; i++)
        {
            if (pellets.GetChild(i).gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
    void resetPellets()
    {
        for (int i = 0; i < pellets.childCount; i++)
        {
            pellets.GetChild(i).gameObject.SetActive(true);
        }
    }
    void resetGhosts()
    {
        for (int i = 0; i < GS.Length; i++)
        {
            GS[i].gameObject.transform.position = GS[i].initPos;
        }
    }

    [Obsolete]
    public void ResetAllPos()
    {
        FreezeGhosts();
        this.pacman.gameObject.SetActive(false);
        Invoke(nameof(resetGhosts), 2.0f);
        Invoke(nameof(reset), 2.0f);
        Invoke(nameof(UnfreezeGhosts), 2.0f);
        resetPellets();
    }
    public void ResetScore()
    {
        scoreCount = 0;
    }
}
