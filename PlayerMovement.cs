﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform mainCamera;
    public Transform groundChecker;
    public CharacterController characterController;
    public LayerMask groundMask;
    public Vector3 verticalVelocity;
    float mouseSensitivity = 100f; 
    float xRotation = 0f;
    float speed = 4f;
    float gravity = 9.81f;
    float groundCheckerDetectionSize = 0.4f;
    float jumpHeight = 1.5f;
    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turnCamera();
        movePlayer();
        fallOrJump();
    }

    void turnCamera()
    {
        turnInAxisX();
        turnInAxisY();
    }

    void turnInAxisX()
    {
        float mouseAxisX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseAxisX);
    }

    void turnInAxisY()
    {
        float mouseAxisY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseAxisY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void movePlayer() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementVector = transform.right * horizontalInput + transform.forward * verticalInput;
        characterController.Move(movementVector * speed * Time.deltaTime);
    }

    void fallOrJump()
    {
        checkIsGrounded();
        clearVerticalVelocityWhenIsGrounded();
        jump();
        addGravityForce();
        characterController.Move(verticalVelocity * Time.deltaTime);
    }

    void clearVerticalVelocityWhenIsGrounded()
    {
        if (isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = 0;
        }
    }

    void checkIsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundCheckerDetectionSize, groundMask);
    }

    void jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            verticalVelocity.y += Mathf.Sqrt(jumpHeight * gravity); 
        }
    }

    void addGravityForce()
    {
        verticalVelocity.y -= gravity * Time.deltaTime;
    }
}
