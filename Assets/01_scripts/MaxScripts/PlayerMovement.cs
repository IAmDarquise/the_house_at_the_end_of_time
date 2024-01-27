using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public Transform arms;
    public float rotationMultiplier;
    public float maximumRotation;
    [Space]
    private PlayerInputActions _playerInputACtions;
    private PlayerInput _playerInput;


    private Rigidbody2D _rb;
    
    
    
    private Vector2 _rotateInput;
    private Vector3 _lastPos;

    public Transform _hand;
    private void Start()
    {
        maximumRotation = maximumRotation * 100;
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        
        _playerInputACtions = new PlayerInputActions();
        _playerInputACtions.Player.Enable();

        _playerInputACtions.Player.Jump.performed += Jump;


    }

    private void Update()
    {
        
        MoveArm();

        if(Input.GetMouseButtonUp(0))
            Throw();
        _lastPos = _hand.position;
    }

    //movement
    private void FixedUpdate()
    {
        float inputVector = _playerInputACtions.Player.Movement.ReadValue<float>();
        float speed = 5f;
        //_rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y)*speed, ForceMode.Force);
        
        // Get the forward direction in local space
        Vector3 forwardDirection = transform.forward;

        // Transform the input vector to world space using the object's forward direction
        Vector3 movement = transform.TransformDirection(new Vector3(inputVector, 0, 0)) * speed;

        // Apply force in the transformed local space
        _rb.AddForce(movement, ForceMode2D.Force);

       

    }

    /*void MoveArm()
    {
        float armVector = _playerInputACtions.Player.MouseMovement.ReadValue<float>();
        float rotationAmount = armVector * rotationMultiplier;

        if (Mathf.Abs(rotationAmount) > 0.0001f)
        {
            Debug.Log(_hand.position);
            Quaternion rotation = Quaternion.Euler(0, 0, -rotationAmount);
            arms.localRotation *= rotation;
            _lastPos = _hand.position;
            Debug.Log(_lastPos);
            
        }
    }*/
   


    private void Jump(InputAction.CallbackContext context)
    {
        _rb.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);
    }

    void MoveArm()
    {
        
        float armVector = _playerInputACtions.Player.MouseMovement.ReadValue<float>();
        float rotationAmount = armVector * rotationMultiplier;

        if (Mathf.Abs(rotationAmount) > 0.1f)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, -rotationAmount);
            arms.localRotation *= rotation;
            
        }
    }

    private void Throw()
    {
        ObjectTouchDetector touch = GetComponentInChildren<ObjectTouchDetector>();
        
        Debug.Log(Vector3.Distance(_lastPos, _hand.position));
        // Check if the mouse is moving (the position changed)
        if (Vector3.Distance(_lastPos, _hand.position) > 0.0001f)
        {
            
            // Calculate the force based on the rotation of the arm
            float throwForce = _lastPos.x + _hand.localPosition.x;

            // Apply the force to the object
            touch.pickedUpObject.GetComponent<Rigidbody2D>()
                .AddForce(new Vector2(throwForce * 2, 0), ForceMode2D.Impulse);
        }
    }


}
