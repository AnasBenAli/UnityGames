using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") < 0)
        {
            this.transform.Translate(Vector3.forward*Time.deltaTime*10f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            this.transform.Translate(Vector3.back * Time.deltaTime*10f);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * 10f);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * 10f);
        }
    }
}
