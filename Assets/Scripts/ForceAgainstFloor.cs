using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAgainstFloor : MonoBehaviour
{
    public Rigidbody m_rigidbody;
    public float force = 1f;
    public LayerMask m_Layermask;
    public float m_DistanceToGround=2f;
    public float m_AddForceNearGround = 0.5f;
    public float m_AddForceFarGround = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit,m_Layermask))
        {
            if (hit.distance < m_DistanceToGround)
            {
                force += m_AddForceNearGround;
            }
            else
            {
                force = m_AddForceFarGround;
            }
            
            m_rigidbody.AddForceAtPosition(transform.TransformDirection(Vector3.up)*force, transform.position, ForceMode.Impulse);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * force, Color.blue);
        }
        
    }
}
