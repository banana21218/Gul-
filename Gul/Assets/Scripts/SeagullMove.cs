using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SeagullMove : MonoBehaviour
{
    private Seagull input = null;
    private Vector3 Mov = Vector3.zero;
    public float movspeed = 8f;
    public Vector3 VelC;


    // Start is called before the first frame update
    void Awake()
    {
        input = new Seagull();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        VelC = Mov * movspeed;
        transform.position += VelC * Time.fixedDeltaTime;

    }
    private void MovM(InputAction.CallbackContext value)
    {
        Mov = value.ReadValue<Vector3>();
    }
    private void MovC(InputAction.CallbackContext value)
    {
        Mov = Vector3.zero;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= MovM;
        input.Player.Move.canceled -= MovC;
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += MovM;
        input.Player.Move.canceled += MovC;
    }

}
