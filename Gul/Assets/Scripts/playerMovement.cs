using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class playerMovement : MonoBehaviour
{
    private Vector2 _fwdbwd;
    private Vector2 _rotation;
    private Vector2 _heightctrl;
    private Vector3 _direction;
    [SerializeField] private Movement movement;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        ApplyMovement();
        ApplyRotation();
        //transform.position += transform.forward * 5f * Time.deltaTime;
    }

    public void move(InputAction.CallbackContext context)
    {
        _fwdbwd = context.ReadValue<Vector2>();
        //Debug.Log(_fwdbwd);
    }
    public void rotate(InputAction.CallbackContext context)
    {
        _rotation = context.ReadValue<Vector2>();
        Debug.Log(_rotation);
    }

    public void heightController(InputAction.CallbackContext context)
    {
        _heightctrl = context.ReadValue<Vector2>();
        Debug.Log(_heightctrl);
    }

    private void ApplyMovement()
    {
        // Forward and Backward
        if(_fwdbwd.y >= 1)
        {
            transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        }
        else if (_fwdbwd.y <= -1)
        {
            transform.Translate(-Vector3.forward * 10f * Time.deltaTime);
        }

        // Rotation
        if(_rotation.x >= 1)
        {
            this.transform.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
        }
        else if (_rotation.x <= -1)
        {
            this.transform.Rotate(0.0f, -1.0f, 0.0f, Space.Self);
        }

        // Forward and Backward
        if (_heightctrl.y >= 1)
        {
            transform.Translate(Vector3.up * 10f * Time.deltaTime);
        }
        else if (_heightctrl.y <= -1)
        {
            transform.Translate(Vector3.down * 10f * Time.deltaTime);
        }
    }

    private void ApplyRotation()
    {

    }
}

[Serializable]
public struct Movement
{
    public float speed;
    public float rotForce;
    public float acceleration;
    public float jumpForceOnOozed;
    public float fallForce;

    public bool isSprinting;
    [HideInInspector] public float currentSpeed;
}