using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    public Transform startPosition;

    private void OnTriggerEnter(Collider other) // Detectamos las colisiones del jugador
    {
        if (other.gameObject.CompareTag("GunAmmo")) // Si colisionamos con un objeto con la tag GunAmmo
        {
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo; // Accedemos a la variable gunAmmo del game manager y le sumamos la munición de la caja de mmunición

            Destroy(other.gameObject); // Destruimos la caja de munición
        }

        if (other.gameObject.CompareTag("HealthObject")) // Si colisionamos con un objeto con la tag HealthObject
        {
            GameManager.Instance.AddHealth(other.gameObject.GetComponent<HealthObject>().health); // Accedemos a la variable healthObject del game manager y le sumamos la munición de la caja de mmunición

            Destroy(other.gameObject); // Destruimos la caja de vida
        }

        if (other.gameObject.CompareTag("DeathFloor")) // Cuando colisionamos con el DeathFloor
        {
            GameManager.Instance.LoseHealth(100); // Perdemos vida

            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = startPosition.position; // Respawneamos
            GetComponent<CharacterController>().enabled = true;
        }

        if (other.gameObject.CompareTag("Objective")) // Cuando colisionamos con el objetivo
        {

            Application.Quit();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet")) // Si colisionamos con la bala de un enemigo
        {
            GameManager.Instance.LoseHealth(5); // Perdemos vida
        }
    }
}
