using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // Detectamos las colisiones del jugador
    {
        if (other.gameObject.CompareTag("GunAmmo")) // Si colisionamos con un objeto con la tag GunAmmo
        {
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo; // Accedemos a la variable gunAmmo del game manager y le sumamos la munición de la caja de mmunición

            Destroy(other.gameObject); // Destruimos la caja de munición
        }

    }
}
