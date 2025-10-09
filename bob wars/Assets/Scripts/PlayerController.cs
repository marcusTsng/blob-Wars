using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Transform))]
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody _rb;
    [SerializeField] private Transform _camTransform;

    [Header("Player Stats")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _moveCap;

    [Header("Camera Stats")]
    [SerializeField] private float _camSensitivity;

    // Inputs
    private float _camX, _camY = 0f;

    // Check variables (for physics)
    private bool _jump = false;
    private bool _grounded = true;
    private float _moveMultiplier = 1f;
    private GameObject _groundedTo;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // CAMERA CONTROLS
        _camTransform.localRotation = Quaternion.Euler(new Vector3(_camY * _camSensitivity, 0, 0));
        transform.rotation = Quaternion.Euler(new Vector3(0, _camX * _camSensitivity, 0));

        _camX += Input.GetAxisRaw("Mouse X");
        _camY -= Input.GetAxisRaw("Mouse Y");
        _camY = Mathf.Clamp(_camY, -30, 30);

        // CAP MOVEMENT
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {
            _moveMultiplier = _moveCap;
        }
        else if (!_grounded)
        {
            _moveMultiplier = 0.5f;
        }
        else
        {
            _moveMultiplier = 1;
        }


        // if (((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))))
        // {
        //     _moveMultiplier = _moveCap;
        // }
        // else
        // {
        //     _moveCap = 1;
        // }

        // MOVEMENT
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(transform.forward * _moveSpeed * _moveMultiplier, ForceMode.Impulse);
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                Vector3 forwardDirection = transform.forward;
                float forwardSpeed = Vector3.Dot(_rb.velocity, forwardDirection);
                if (forwardSpeed > 0.01f)
                {
                    _rb.velocity -= forwardDirection * forwardSpeed;
                }
                else if (forwardSpeed < -0.01f)
                {
                    _rb.velocity -= forwardDirection * forwardSpeed;
                }
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(transform.right * _moveSpeed * _moveMultiplier * -1, ForceMode.Impulse);
        }
       else
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                Vector3 rightDirection = transform.right;
                float rightSpeed = Vector3.Dot(_rb.velocity, rightDirection);
                if (rightSpeed > 0.01f)
                {
                    _rb.velocity -= rightDirection * rightSpeed;
                }
                else if (rightSpeed < -0.01f)
                {
                    _rb.velocity -= rightDirection * rightSpeed;
                }
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(transform.forward * _moveSpeed * _moveMultiplier * -1, ForceMode.Impulse);
        }
        else 
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                Vector3 forwardDirection = transform.forward;
                float forwardSpeed = Vector3.Dot(_rb.velocity, forwardDirection);
                if (forwardSpeed > 0.01f)
                {
                    _rb.velocity -= forwardDirection * forwardSpeed;
                }
                else if (forwardSpeed < -0.01f)
                {
                    _rb.velocity -= forwardDirection * forwardSpeed;
                }
            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(transform.right * _moveSpeed * _moveMultiplier, ForceMode.Impulse);
        }
       else
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                Vector3 rightDirection = transform.right;
                float rightSpeed = Vector3.Dot(_rb.velocity, rightDirection);
                if (rightSpeed > 0.01f)
                {
                    _rb.velocity -= rightDirection * rightSpeed;
                }
                else if (rightSpeed < -0.01f)
                {
                    _rb.velocity -= rightDirection * rightSpeed;
                }
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _jump = true;
        }
    }
    private void FixedUpdate()
    {
        if (_jump)
        {
            _jump = false;
            Jump();
        }
        _rb.velocity = new Vector3(Mathf.Clamp(_rb.velocity.x, -_moveSpeed, _moveSpeed), _rb.velocity.y, Mathf.Clamp(_rb.velocity.z, -_moveSpeed, _moveSpeed));
    }

    private void Jump()
    {
        if (_grounded)
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);                
            //_rb.velocity = Vector3.up * _jumpPower;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Player"))
        {
            _grounded = true;
            _groundedTo = collider.gameObject;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == _groundedTo)
        {
            _grounded = false;
            _groundedTo = null;
        }
    }

}
