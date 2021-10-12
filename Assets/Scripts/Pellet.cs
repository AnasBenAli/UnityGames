using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public GameManager gm;
    private int scoreValue = 10;
    
     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Pacman")
        {
            gm.scoreCount = gm.scoreCount + scoreValue;
            Destroy(this.gameObject);
        }
    }
}
