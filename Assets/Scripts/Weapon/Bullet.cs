using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) // Cuando el objeto colisione con algo, lo guarda dentro de la variable collision
    {
        if(collision.gameObject.CompareTag("Enemy")) // Si hemos colisionado con un objeto que tiene el tag Enemy
        {
            Destroy(collision.gameObject); // Destruimos el objeto
        }
    }
}
