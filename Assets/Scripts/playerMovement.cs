using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform childTransform;

    public float gravity = -300f;

    public Vector3 velocity;

    public float speed = 120f;

    // defining public variables 

    void turnPlayer() {
        float mouseSensitivity = 100f;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
    }
    // function to rotate player based on mouse movement (x-axis)

    void moveplayer() {
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(30f * -2f * gravity);
        }
        // jump block

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 y = new Vector3(0, -0.001f, 0);
        // push player down to collide with ground so controller.isGrounded is true

        Vector3 move = transform.right * x + y + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

    }
    // moves player based on input and players current position, using character controller

    void gravityEffect() {
        if (controller.isGrounded && velocity.y <= 0) {
            velocity.y = 0f;
        }
        // reset velocity if character on ground

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
    // produces effect of gravity on player object, forcing it to the ground

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // lock cursor
    }

    void Update()
    {
        turnPlayer();
        moveplayer();
        gravityEffect();
    }
}
