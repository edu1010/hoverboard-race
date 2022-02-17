using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Actions;

public class Movement : MonoBehaviour, IPlayerActions
{
    KeyCode m_KeyAdvance = KeyCode.W;
    Rigidbody m_rigidbody;
    public float m_force=1;
    private Vector3 movement;
    bool m_IsMoving = false;
    public GameObject m_Camera;
    public GameObject m_Renderer;

    public float m_RotationQuantity = 15;
    public float m_TimeToRotate = 1.5f;
    Quaternion m_TargetRotation = Quaternion.identity;
    bool m_root = false;
    float rateTiempo;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsMoving)
        {
            m_rigidbody.AddForce(movement * m_force, ForceMode.Force);
        }
        if (m_root)
        {
            RotateRenderer();
        }
        else
        {
            m_TargetRotation = Quaternion.identity;
            RotateRenderer();
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector3 l_Forward = m_Camera.transform.forward;
        Vector3 l_Right = m_Camera.transform.right;
        l_Forward.y = 0.0f;
        l_Right.y = 0.0f;

        l_Forward.Normalize();
        l_Right.Normalize();
        switch (context)
        {
            case var value when !context.canceled:
            movement = Vector3.zero;
            if (context.ReadValue<Vector2>().x > 0)
            {
                    movement += l_Right;
                    CalculateRotateRenderer(true);
            }
            else if (context.ReadValue<Vector2>().x < 0)
            {
                    movement -= l_Right;
                    CalculateRotateRenderer(false);
            }
            else
            {
            m_root = false;
            }

            if (context.ReadValue<Vector2>().y > 0)
                movement += l_Forward;
            else if (context.ReadValue<Vector2>().y < 0)
                movement -= l_Forward;

                movement.Normalize();
                m_IsMoving = true;
                    break;
            case var value when context.canceled:
                m_IsMoving = false;
                m_root = false;
                break;
            
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void CalculateRotateRenderer(bool right)
    {
        if (right)
        {
            m_TargetRotation = Quaternion.Euler(m_Renderer.transform.rotation.eulerAngles.x,
                m_Renderer.transform.rotation.eulerAngles.y,
                - m_RotationQuantity);
        }
        else
        {
            m_TargetRotation = Quaternion.Euler(m_Renderer.transform.rotation.eulerAngles.x,
               m_Renderer.transform.rotation.eulerAngles.y,
               m_RotationQuantity);
        }
        m_root = true;
    }

    void RotateRenderer()
    {
       
        rateTiempo = 1f / m_TimeToRotate;
        float t = 0.0f;
        if (t <= 1f)
        {
            t += Time.deltaTime * rateTiempo;
            m_Renderer.transform.rotation = Quaternion.Lerp(m_Renderer.transform.rotation, m_TargetRotation, t);
        }
    }

}
