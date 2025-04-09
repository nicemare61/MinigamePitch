using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private Rigidbody rb;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float turningRate = 30f;
 
    [SerializeField] private float xInput;
    [SerializeField] private float zInput;
     
    [Header("Zoom")]
    [SerializeField] private float zoomModifier;
    
    [SerializeField] private GameObject ballKick;
    private bool haveBall;
    public bool alive;
    
    private void MoveByKB()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        Vector3 dir = (transform.forward * zInput)+ (transform.right * xInput);
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        MoveByKB();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateBall();
        }
    }

    private void GenerateBall()
    {
        Instantiate(ballKick, transform.position + new Vector3(1,0,0), transform.rotation);
        Rigidbody ballRb = ballKick.GetComponent<Rigidbody>();
        ballRb.AddForce(transform.forward, ForceMode.Impulse);
    }
    
}
