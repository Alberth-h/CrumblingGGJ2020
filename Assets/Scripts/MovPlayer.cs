﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    public float gravity = 9.8f;

    public float horizontalMove;
    public float verticalMove;
    public CharacterController player;

    private Vector3 playerInput;

    public float playerSpeed;
    private Vector3 movePlayer;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        camDirection();

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

    }
    private void FixedUpdate()
    {
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        player.transform.LookAt(player.transform.position + movePlayer);
        SetGravity();
        player.Move(movePlayer * playerSpeed);
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void SetGravity()
    {
        movePlayer.y = -gravity * Time.deltaTime;
    }

}