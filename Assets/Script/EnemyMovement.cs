using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private RaycastHit hit;
    public GameObject player;
    private Vector3 Playerdirection;
    Vector3 freepath = Vector3.zero;
    //bool found_freepath = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Playerdirection = (transform.position - player.transform.position) * -1;
    }
     void FixedUpdate()
    {
        check_path();
    }
    void goTowards(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime);
    }
    void check_path()
    {
        Vector3 dir = new Vector3(-1,0,1)*2;

        if (!Physics.Raycast(transform.position, Playerdirection, out hit, 10f ))
        {
            Debug.DrawRay(transform.position, Playerdirection, Color.blue);
            goTowards(Playerdirection);
        }
        if (Physics.Raycast(transform.position, Playerdirection, out hit, 10f) && hit.collider.gameObject.name == "Player")
        {
            Debug.DrawRay(transform.position, Playerdirection, Color.blue);
            goTowards(Playerdirection);
        }
         if(Physics.Raycast(transform.position, Playerdirection, out hit, 10f) && hit.collider.gameObject.layer == 7)
        { 
            for(float i=0;i<360;i=i+0.1f)
            {
               if(!Physics.Raycast(transform.position, Playerdirection + dir * i, out hit, 10f) || !Physics.Raycast(transform.position, Playerdirection + dir *-i, out hit, 10f))
                {
                    if(!Physics.Raycast(transform.position, Playerdirection + dir * -i, out hit, 10f))
                    {
                        dir = dir * -1;
                    }
                    freepath = Playerdirection + dir * i;
                    Debug.DrawRay(transform.position, freepath, Color.green);
                    break;
                }
            }
            goTowards(freepath);
        }
            else
            {
                
            }
    }
    
    
}
