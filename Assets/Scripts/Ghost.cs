using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Vector3 initPos;
    public int value = 100;

    private void Awake()
    {
        initPos = this.gameObject.transform.position;
    }

}
