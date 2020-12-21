using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float jumpSpeed = 0.5f;
    [SerializeField] private float gravity = 2;

    CharacterController characterController;
    Vector3 moveDir;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
        Vector3 transformDirection = transform.TransformDirection(inputDirection);

        Vector3 flatMovement = moveSpeed * Time.deltaTime * transformDirection;

        moveDir = new Vector3(flatMovement.x, moveDir.y, flatMovement.z);

        if (playerJumped)
            moveDir.y = jumpSpeed;

        else if (characterController.isGrounded)
            moveDir.y = 0;

        else
            moveDir.y -= gravity * Time.deltaTime;

        characterController.Move(moveDir);
    }

    private bool playerJumped => characterController.isGrounded && Input.GetKey(KeyCode.Space);
}
