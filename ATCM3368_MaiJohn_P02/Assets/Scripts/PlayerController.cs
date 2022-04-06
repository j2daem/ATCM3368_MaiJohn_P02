using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController characterController = null;
    [SerializeField] float movementSpeed = 12f;
    [SerializeField] float sprintSpeed = 24f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    float x;
    float z;
    Vector3 velocity;
    bool isGrounded;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //Created a direct you can move based on way player is facing
        Vector3 move = transform.right * x + transform.forward * z;
        if (move.magnitude > 1)
        {
            move /= move.magnitude;
        }

        characterController.Move(move * movementSpeed * Time.deltaTime);

        //Increase player movement (sprint) while left shift is held
        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(move * sprintSpeed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            characterController.Move(move * movementSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
