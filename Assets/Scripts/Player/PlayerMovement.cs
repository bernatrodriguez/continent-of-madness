using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    public float speed = 12f; // Velocidad de movimiento del personaje

    private float gravity = -9.81f; // Gravedad (ref. Tierra) // Hacemos la variable privada para que no pueda ser modificada en el editor y evitar posibles problemas


    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;

    bool isGrounded;


    Vector3 velocity;


    public float jumpHeight = 3;


    public bool isSprinting;

    public float sprintingSpeedMultiplier = 1.5f;

    private float sprintSpeed = 1;


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

        JumpCheck();

        RunCheck();


        characterController.Move(move * speed * Time.deltaTime * sprintSpeed); // Multiplicamos por Time.deltaTime para que sea independiente de los FPS

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    public void JumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Si recibimos la tecla espacio y estamos tocando el suelo (si no comprobáramos el suelo podríamos encadenar saltos de forma infinita)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); // Fórmula para el salto en el eje Y
        }
    }

    public void RunCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = !isSprinting;
        }

        if (isSprinting == true)
        {
            sprintSpeed = sprintingSpeedMultiplier;
        }
        else
        {
            sprintSpeed = 1;
        }

    }
}
