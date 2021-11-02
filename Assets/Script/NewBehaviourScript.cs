using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector2 initPos;
    private Vector2 endPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.touchCount);
        if(Input.touchCount != 0)
        {
           if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                initPos = Input.GetTouch(0).position;
                Debug.Log(initPos);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Debug.Log("Touch Moved");
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endPos = Input.GetTouch(0).position;
                Debug.Log(endPos);
            }
        }
    }
}
