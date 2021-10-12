using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour
{
    private Rigidbody rb;
    public float speedFactor=1;
    public GameManager gm;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      
    }
    void Update()
    {
        if (!gm.isPaused)
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
            {
            rb.velocity = new Vector3(-h, 0, -v) * 1000f * speedFactor * Time.deltaTime;
            }
        }
        else
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            this.gameObject.SetActive(false);
        }
    }
}
