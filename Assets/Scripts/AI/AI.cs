using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Añadimos una librería de inteligencia artificial

public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent; // Referenciamos el navMeshAgent del objeto al que queremos aplicar el script

    public Transform[] destinations; // Referenciamos un array para los puntos de destino

    public float distanceToFollowPath = 2; // Distancia que hace falta al llegar a un destino para pasar al siguiente

    private int i = 0; // Indice

    [Header("Seguir jugador: (Si / No)")]

    public bool followPlayer; // Booleano para definir si queremos seguir al jugador o no

    private GameObject player; // Referencia a nuestro jugador

    private float distanceToPlayer; // Dstancia al jugador

    public float distanceToFollowPlayer = 10; // Distancia mínima para seguir al jugador


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.destination = destinations[0].transform.position; // En un primer momento, el enemigo irá al punto 0 del array
        player = FindObjectOfType<PlayerMovement>().gameObject; // Referenciamos al jugador para poder trabajar con sus variables
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position); // Calculamos la distancia del enemigo al jugador

        if (distanceToPlayer <= distanceToFollowPlayer && followPlayer) // Si la distancia del enemigo al jugador es igual o menor que la mínima para seguirlo, y si followPlayer es verdadero
        {
            FollowPlayer(); // El enemigo sigue al jugador
        }
        else // Sino
        {
            EnemyPath(); // El enemigo sigue su ruta
        }
    }

    public void EnemyPath() // Función que define la ruta del enemigo
    {
        navMeshAgent.destination = destinations[i].position; // Establecemos el destino del enemigo en el punto destinations[i] del array

        if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath) // Si la distancia entre el enemigo y su destino es menor o igual a la necesaria para pasar al destino siguiente
        {
            if (destinations[i] != destinations[destinations.Length - 1]) // Comprobación para verificar que hay otro destino más en el array, evitamos errores
            {
                i++; // Sumamos 1 a nuestro destino (pasamos al siguiente)
            }
            else
            {
                i = 0; // Volvemos al destino inicial
            }
        }
    }

    public void FollowPlayer() //Función que añade el trackeo del jugador por parte del enemigo
    {
        navMeshAgent.destination = player.transform.position; // Establecemos el destino del enemigo en la posición del jugador
    }

    public void GrenadeImpact()
    {
        Destroy(gameObject);
    }
}