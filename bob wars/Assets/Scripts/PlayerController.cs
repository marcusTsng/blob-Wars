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

    [Header("Camera Stats")]
    [SerializeField] private float _camSensitivity;

    // Inputs
    private float _inpX, _inpY = 0f;
    private float _camX, _camY = 0f;

    // Check variables (for physics)
    private bool _jump = false;
    private bool _grounded = true;
    private GameObject _groundedTo;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        // CAMERA CONTROLS
        _camTransform.localRotation = Quaternion.Euler(new Vector3(_camY * _camSensitivity, 0, 0));
        transform.rotation = Quaternion.Euler(new Vector3(0, _camX * _camSensitivity, 0));

        _camX += Input.GetAxisRaw("Mouse X");
        _camY -= Input.GetAxisRaw("Mouse Y");

        // MOVEMENT
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(transform.forward * _moveSpeed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(transform.right * _moveSpeed * -1, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(transform.forward * _moveSpeed * -1, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(transform.right * _moveSpeed, ForceMode.Impulse);
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
    }

    // JUMP FUNCTIONS
    private void Jump()
    {
        if (_grounded)
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
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
