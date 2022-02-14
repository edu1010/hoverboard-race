using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardAngle : MonoBehaviour
{
    public Transform frontEdge;
    public Transform backEdge;
    float pitch;
    float yaw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() { 

        Vector3 tmp = frontEdge.position - backEdge.position;
        tmp.Normalize();
        //pitch = Vector3.Angle(frontEdge.forward, tmp);
        
       
        
        transform.rotation =  Quaternion.Euler(pitch, 0f, 0f);
        
    }
}
