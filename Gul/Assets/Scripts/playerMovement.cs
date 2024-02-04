using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
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

    public Transform front;
    public Transform back;

    public int food;
    public bool canPoo = true;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        canPoo = true;
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
       //Debug.Log(_rotation);
    }

    public void heightController(InputAction.CallbackContext context)
    {
        _heightctrl = context.ReadValue<Vector2>();
        //Debug.Log(_heightctrl);
    }

    public void pooping(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            throwPoop();
        }
    }

    private void ApplyMovement()
    {
        // Forward and Backward
        if(_fwdbwd.y >= 1)
        {
            if(movementCheck(this.transform.forward, front.transform.position))
                transform.Translate(movement.speed * 10f * Vector3.forward * Time.deltaTime);
        }
        else if (_fwdbwd.y <= -1)
        {
            if (movementCheck(this.transform.forward * -1, back.transform.position))
                transform.Translate(movement.speed * 10f * -Vector3.forward * Time.deltaTime);
        }

        // Rotation
        if(_rotation.x >= 1)
        {
            //this.transform.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
            this.transform.Rotate(movement.rotateForce * 10f * new Vector3(0,1,0) * Time.deltaTime, Space.Self);
        }
        else if (_rotation.x <= -1)
        {
            this.transform.Rotate(movement.rotateForce * 10f * new Vector3(0, -1, 0) * Time.deltaTime, Space.Self);
        }

        // Forward and Backward
        if (_heightctrl.y >= 1)
        {
            transform.Translate(movement.heightChangeSpeed * 10f * Vector3.up * Time.deltaTime);
        }
        else if (_heightctrl.y <= -1)
        {
            if (GroundCheck())
            {
                transform.Translate(movement.heightChangeSpeed * 10f * Vector3.down * Time.deltaTime);
            }
            //transform.Translate(Vector3.down * 10f * Time.deltaTime);
        }
    }

    private void ApplyRotation()
    {

    }

    private void checkForPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
    }

    private bool movementCheck(Vector3 direction, Vector3 origin)
    {
        RaycastHit hit;
        //Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity)
        if (Physics.Raycast(origin, direction, out hit, Mathf.Infinity))
        {
            //Debug.Log(hit.distance);
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            if (hit.distance < 1)
            {
                if(hit.transform.tag == "Interactable")
                {
                    return true;
                }
                Debug.DrawRay(origin, direction, Color.red);
                return false;
            }
            else
            {
                Debug.DrawRay(origin, direction, Color.yellow);
                return true;
            }
        }

        return false;
    }

    private bool GroundCheck()
    {
        RaycastHit hit;
        //Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity)
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            //Debug.Log(hit.distance);
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            if (hit.distance < 0.4)
            {
                Debug.DrawRay(transform.position, Vector3.down, Color.red);
                return false;
            }
            else
            {
                Debug.DrawRay(transform.position, Vector3.down, Color.yellow);
                return true;
            }
        }

        return false;
    }

    private void throwPoop()
    {
        if(canPoo == true)
        {
            canPoo = false;
            StartCoroutine(poopTimer());
        }
        else
        {
            Debug.Log("Can't poop yet");
        }
    }

    private IEnumerator poopTimer()
    {
        Debug.Log("Pooped");
        yield return new WaitForSeconds(5f);
        canPoo = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Interactable")
        {
            Debug.Log("Collided with interactable");
        }
    }
}


[Serializable]
public struct Movement
{
    public float speed;
    public float heightChangeSpeed;
    public float rotateForce;
}