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

    public float sensitivity = 150f;
    public float clampAngle = 85f;

    private float verticalRotation;
    private float horizontalRotation;

    private void Start() {
        verticalRotation = transform.localEulerAngles.x;
        horizontalRotation = transform.eulerAngles.y;
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

        Look();

        if (Input.GetKey(KeyCode.E))
            Cursor.lockState = CursorLockMode.None;

        if (Input.GetKey(KeyCode.Q))
            Cursor.lockState = CursorLockMode.Locked;

        if (Vector3.Distance(transform.localPosition, Vector3.zero) > 250f) {
            transform.localPosition = new Vector3(0, 50, 0);
        }

    }

    private bool playerJumped => characterController.isGrounded && Input.GetKey(KeyCode.Space);

    private void Look() {
        float _mouseVertical = -Input.GetAxis("Mouse Y");
        float _mouseHorizontal = Input.GetAxis("Mouse X");

        verticalRotation += _mouseVertical * sensitivity * Time.deltaTime;
        horizontalRotation += _mouseHorizontal * sensitivity * Time.deltaTime;

        verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);
    }
}
