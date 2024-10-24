using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerController : MonoBehaviour
{
    [Header("Element")]
    private Joystick joystick;
    private CharacterController characterController;
    private PlayerAnimator playerAnimator;

    [Header("Setting")]
    [SerializeField] float moveSpeed;
    public float xInput;
    public float yInput;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        joystick = FindFirstObjectByType<Joystick>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }
    private void Update()
    {
        ManageMovement();
    }
    private void ManageMovement()
    {
        Vector3 moveDirection = GetMoveDirection();
        Vector3 moveVector = CalculationMoveVector(moveDirection);

        // Sử dụng CharacterController để di chuyển nhân vật
        characterController.Move(moveVector);
        playerAnimator.ManageAnimations(moveVector);// animation

    }
    private Vector3 GetMoveDirection()
    {
        xInput = joystick.Horizontal;
        yInput = joystick.Vertical;

        // Tạo hướng di chuyển từ input joystick
        Vector3 moveDirection = new Vector3(xInput, 0, yInput);
        return moveDirection;
    }
    private Vector3 CalculationMoveVector(Vector3 moveDirection)
    {
        if (moveDirection.magnitude > 1)
        {
            moveDirection = moveDirection.normalized;
        }
        return moveDirection * moveSpeed * Time.deltaTime;
    }    
}
