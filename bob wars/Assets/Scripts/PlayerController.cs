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
    private float _camX = 0f;
    private float _camY = 0f;

    private void Awake(){

    }

    private void Start(){

    }

    private void Update(){
        _camTransform.rotation = Quaternion.Euler(new Vector3(_camY * _camSensitivity, 0, 0));
        transform.rotation = Quaternion.Euler(new Vector3(0, _camX * _camSensitivity, 0));

        _camX += Input.GetAxisRaw("Mouse X");
        _camY -= Input.GetAxisRaw("Mouse Y");
    }

    private void FixedUpdate(){

    }
}
