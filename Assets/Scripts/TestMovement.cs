using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private Vector3 _velocity;
    [SerializeField]
    private float moveSpeed = 10f; 
    [SerializeField]
    private float rotationSpeed = 360f;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        var direction = transform.TransformDirection(Vector3.forward);//Vector3.forward;
        _velocity = direction * (moveSpeed * Time.fixedDeltaTime);
        //transform.Rotate(new Vector3(0f, 1f * rotationSpeed * Time.fixedDeltaTime, 0f));
        //transform.Translate(_velocity);
        _characterController.Move(_velocity);


        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2.0f, LayerMask.GetMask("Bounds")))
        {
            transform.Rotate(Vector3.up, 180f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Bounds"))
        {
            Debug.Log("Collide");
            transform.Rotate(Vector3.up, 90f);
        }
    }
    
}
