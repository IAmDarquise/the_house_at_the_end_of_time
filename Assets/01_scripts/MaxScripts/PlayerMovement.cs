using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public bool reversed;
    public float speed = 10f;
    public float jumpDist = 10f;
    public Transform arms;
    public Transform arm2;
    public float rotationMultiplier;
    public float maximumRotation;
    [Space]
    private PlayerInputActions _playerInputACtions;
    private PlayerInput _playerInput;


    private Rigidbody2D _rb;
    private bool _grounded;
    
    
    private Vector2 _rotateInput;
    private Vector3 _lastPos;

    public Transform _hand;
    
    //animations
    private Animator _anim;
    private void Start()
    {
        maximumRotation = maximumRotation * 100;
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        
        _playerInputACtions = new PlayerInputActions();
        _playerInputACtions.Player.Enable();

        _playerInputACtions.Player.Jump.performed += Jump;


        _anim = GetComponent<Animator>();
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
        
        //_rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y)*speed, ForceMode.Force);
        
        // Get the forward direction in local space
        Vector3 forwardDirection = transform.forward;
        Vector3 movement;
        if (!reversed)
        {
            // Transform the input vector to world space using the object's forward direction
            movement = transform.TransformDirection(new Vector3(inputVector, 0, 0)) * speed;
        }
        else
        {
            movement = transform.TransformDirection(new Vector3(-inputVector, 0, 0)) * speed;
        }

        // Apply force in the transformed local space
        _rb.AddForce(movement, ForceMode2D.Force);
        
        SetAnimSpeed();
    }

    
   


    private void Jump(InputAction.CallbackContext context)
    {
        if(_grounded)
            _rb.AddForce(Vector3.up * jumpDist, ForceMode2D.Impulse);
    }

    void MoveArm()
    {
        
        
        float armVector = _playerInputACtions.Player.MouseMovement.ReadValue<float>();
        float rotationAmount = 0;
        if(!reversed)
            rotationAmount = armVector * rotationMultiplier;
        if(reversed)
            rotationAmount = -armVector * rotationMultiplier;

//        Debug.Log(arms.eulerAngles.z);
        if (arms.eulerAngles.z > 90 && arms.eulerAngles.z < 270)
        {
            if(arms.eulerAngles.z < 100)
                arms.localEulerAngles = new Vector3(arms.localEulerAngles.x, arms.localEulerAngles.y,90 );
            if(arms.eulerAngles.z < 280 && arms.eulerAngles.z > 150)
                arms.localEulerAngles = new Vector3(arms.localEulerAngles.x, arms.localEulerAngles.y,270 );
        }

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
            //
            // Calculate the force based on the rotation of the arm
            float throwForce = _lastPos.x + _hand.localPosition.x;

            // Apply the force to the object
            touch.pickedUpObject.GetComponent<Rigidbody2D>()
                .AddForce(new Vector2(throwForce * 2, 0), ForceMode2D.Impulse);
        }
    }
    /*private void Throw()
    {
        ObjectTouchDetector touch = GetComponentInChildren<ObjectTouchDetector>();

        // Calculate the direction of the throw based on the sign of the armVector
        float throwDirection = Mathf.Sign(_playerInputACtions.Player.MouseMovement.ReadValue<float>());

        // Calculate the force based on the rotation of the arm and throw direction
        float throwForce = _lastPos.x + _hand.localPosition.x * throwDirection;

        // Apply the force to the object
        touch.pickedUpObject.GetComponent<Rigidbody2D>()
            .AddForce(new Vector2(throwForce * 2, 0), ForceMode2D.Impulse);
    }*/

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Ground"))
            _grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
            _grounded = false;
    }

    private void SetAnimSpeed()
    {
//        Debug.Log(_anim.speed);
        _anim.speed = _rb.velocity.magnitude;
    }

    public void Reverse()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
        reversed = true;
        //arms = arm2;
        //arms.GetComponentInChildren<Collider2D>().enabled = true;
    }

}
