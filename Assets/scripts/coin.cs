using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class coin : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        transform.Rotate(20 * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playermanager.numberOfCoins += 1;
            Destroy(gameObject); 
        }
    }
}