using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    public float speed = 12f; // Velocidad de movimiento del personaje

    private float gravity = -9.81f; // Gravedad (ref. Tierra)


    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;

    bool isGrounded;


    Vector3 velocity;


    public float jumpHeight = 3;


    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask); // Booleano que nos dice si estamos en el suelo

        if (isGrounded && velocity.y < 0) // Cuando estamos tocando el suelo y llevamos una velocidad negativa en el eje Y (estamos cayendo)
        {
            velocity.y = -2f; // Establecemos continuamente la velocidad del eje Y en -2, esto evitará que el personaje aumente su velocidad de forma constante por la gravedad
        }


        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }


        characterController.Move(move * speed * Time.deltaTime); // Multiplicamos por Time.deltaTime para que sea independiente de los FPS

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }
}
