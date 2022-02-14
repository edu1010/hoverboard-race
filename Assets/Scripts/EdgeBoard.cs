using Steerings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeBoard : MonoBehaviour
{
    GameObject target;
    public bool frontEdge=false;
    public bool backEdge=false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject ob = new GameObject();
        target = ob;
        if (frontEdge)
        {
            transform.parent.GetComponent<BoardAngle>().frontEdge = target.transform;
        }else if (backEdge)
        {
            transform.parent.GetComponent<BoardAngle>().backEdge = target.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            
         
                Vector3 desirePoint = hit.point + hit.normal * 2f;
                target.transform.position = desirePoint;
            //arrive.target = target;
            
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            
        }

        
    }
}
