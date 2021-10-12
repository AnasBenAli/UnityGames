using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform pallets;
    public GameObject pacman;
    public Text Score;
    public Transform Ghosts;
    public Button pause;
    public bool isPaused {get;set;}
    public int scoreCount { get; set; }
    void Start()
    {
        scoreCount = 0;
        isPaused = true;

        pause.onClick.AddListener(() =>
        {
            if (isPaused)
            {
                isPaused = false;
                pause.GetComponentInChildren<Text>(true).text = "Pause";
            }
            else
            {
                isPaused = true;
                pause.GetComponentInChildren<Text>(true).text = "Play";
            }
        });
    }
        
        
    
    [System.Obsolete]
    void Update()
    {
        
        if (!isPaused)
        {
            Score.text = "Score: " + scoreCount.ToString();
            if (pallets.childCount == 0)
            {
                pacman.SetActive(false);
                FreezeGhosts();
            }
            UnfreezeGhosts();

        }
        else
        {
            FreezeGhosts();
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

}
