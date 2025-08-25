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

    [Header("Camera Stats")]
    [SerializeField] private float _camSensitivity;

    // Inputs
    private float _inpX, _inpY = 0f;
    private float _camX, _camY = 0f;

    private void Awake(){
        _rb = GetComponent<Rigidbody>();
    }

    private void Start(){
    }

    private void Update(){
        // CAMERA CONTROLS
        _camTransform.localRotation = Quaternion.Euler(new Vector3(_camY * _camSensitivity, 0, 0));
        transform.rotation = Quaternion.Euler(new Vector3(0, _camX * _camSensitivity, 0));

        _camX += Input.GetAxisRaw("Mouse X");
        _camY -= Input.GetAxisRaw("Mouse Y");

        // MOVEMENT
        if (Input.GetKey(KeyCode.W)){
            _rb.AddForce(transform.forward * _moveSpeed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A)){
            _rb.AddForce(transform.right * _moveSpeed * -1, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S)){
            _rb.AddForce(transform.forward * _moveSpeed * -1, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D)){
            _rb.AddForce(transform.right * _moveSpeed, ForceMode.Impulse);
        }
    }

    private void FixedUpdate(){
    }
}
