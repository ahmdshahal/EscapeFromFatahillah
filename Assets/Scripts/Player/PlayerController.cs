using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    
    private CharacterController controller;
    private InputManager inputManager;
    private Vector3 playerVelocity;
    private Vector3 originalPositionCam;
    private bool isGrounded;
    private bool isCrouch;
    private bool isSprint;
    private bool isPause;

    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputManager = GetComponent<InputManager>();
    }

    private void Start()
    {
        isCrouch = false;
        isSprint = false;

        originalPositionCam = cam.transform.localPosition;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (inputManager.onFootActions.Crouch.triggered) Crouch();

    }


    /// <summary>
    /// Receive the inputs for our InputManager.cs and Apply them to our Character Controller.
    /// </summary>
    public void Movement(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        if (Camera.main != null)
            controller.Move(Camera.main.transform.TransformDirection(moveDirection) * (speed * Time.deltaTime));

        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0) 
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
        
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch()
    {
        isCrouch = !isCrouch;

        cam.transform.localPosition = isCrouch ? originalPositionCam / 2.7f : originalPositionCam;
        speed = isCrouch ? 3 : 5;
    }

    public void Sprint()
    {
        isSprint = !isSprint;
        
        if (isSprint && !isCrouch)
            speed = 8;
        else if(!isSprint && !isCrouch)
            speed = 5;
    }

    public void Pause()
    {
        isPause = !isPause;
        
        if(isPause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
