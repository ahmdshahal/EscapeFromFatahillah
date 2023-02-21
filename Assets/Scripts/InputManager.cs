using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerController playerController;
    private PlayerLook playerLook;

    public PlayerInput.OnFootActions onFootActions;
    public PlayerInput.OnUIActions onGameActions;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFootActions = playerInput.OnFoot;
        onGameActions = playerInput.OnUI;

        playerController = GetComponent<PlayerController>();
        playerLook = GetComponent<PlayerLook>();

        onFootActions.Jump.performed += ctx => playerController.Jump();
        onFootActions.Sprint.performed += ctx => playerController.Sprint();

        onGameActions.Pause.performed += ctx => playerController.Pause();
    }

    void FixedUpdate()
    {
        //Tell the PlayerController.cs to move using the value from our movement action
        playerController.Movement(onFootActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerLook.Look(onFootActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFootActions.Enable();
        onGameActions.Enable();
    }

    private void OnDisable()
    {
        onFootActions.Disable();
        onGameActions.Disable();
    }
}
