using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class THROWAWAYcheckingPlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    private InputManager _input;
    private Rigidbody _rb;
    private float _speed = 100;
    void Start()
    {
        if (_input == null)
        {
            _input = FindObjectOfType<InputManager>();
        }

        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        RightMovement();
    }

    private void RightMovement()
    {
        switch (_input.rightState)
        {
            case RightState.None:
                _rb.velocity = Vector3.zero;
                break;
            case RightState.Left:
                _rb.velocity = (Vector3.left * (_speed * Time.deltaTime));
                break;
            case RightState.Right:
                _rb.velocity = (Vector3.right * (_speed * Time.deltaTime));
                break;
        }
    }
}
