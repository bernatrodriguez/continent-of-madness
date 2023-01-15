using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3; // Segundos antes de que explote la granada

    private float countdown;

    public float radius = 5; // Radio de explosión de la granada

    public float explosionForce = 70; // Fuerza de explosión de la granada

    bool exploded = false; // Booleano que nos indica si la granada ha explotado o no

    public GameObject explosionEffect; // Partícula de explosión

    private AudioSource audioSource;
    public AudioClip explosionSound;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {

        countdown -= Time.deltaTime; // Reducimos constantemente el valor de countdown, es decir, el tiempo antes de que explote la granada

        if (countdown <= 0 && exploded == false)
        {
            Explode(); // Llamamos al método explode, que crea la explosión
            exploded = true; // Cambiamos el valor del booleano para que no se vuelva a repetir la explosión
        }
        
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation); // Instanciamos la partícula de explosión en la posición de la granada

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius); // Array de objetos con los que ha colisionado la granada en el radio definido

        foreach (var rangeObjects in colliders) // Por cada objeto que esté dentro del array de objetos
        {
            AI ai = rangeObjects.GetComponent<AI>();

            if (ai != null)
            {
                ai.GrenadeImpact();
            }

            Rigidbody rb = rangeObjects.GetComponent<Rigidbody>(); // Vamos a coger su componente Rigidbody

            if (rb != null) // Si el Rigidbody no es nulo, es decir, tiene Rigidbody
            {
                rb.AddExplosionForce(explosionForce*10, transform.position, radius); // Añadimos una fuerza de explosión
            }
        }

        audioSource.PlayOneShot(explosionSound);

        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        Destroy(gameObject, delay*2); // Destruimos la granada
        
    }
}
