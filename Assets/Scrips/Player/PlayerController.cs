using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        xInput = joystick.Horizontal;
        yInput = joystick.Vertical;

        // Tạo hướng di chuyển từ input joystick
        Vector3 moveDirection = new Vector3(xInput, 0, yInput);

        // có input từ joystick, chuẩn hóa hướng di chuyển để tốc độ ổn định
        if (moveDirection.magnitude > 1)
        {
            moveDirection = moveDirection.normalized;
        }

        // Tính toán vector di chuyển 
        Vector3 moveVector = moveDirection * moveSpeed * Time.deltaTime;

        // Sử dụng CharacterController để di chuyển nhân vật
        characterController.Move(moveVector);
        
        playerAnimator.ManageAnimations(moveVector);// animation
        
    }
    
}
