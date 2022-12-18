using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject bullet;

    public float shotForce = 1500f;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Cuando pulsamos el click izquierdo del ratón
        {
            if (Time.time > shotRateTime && GameManager.Instance.gunAmmo > 0) // Comprobamos el tiempo y si nos queda munición
            {
                GameManager.Instance.gunAmmo--; // Gastamos 1 de munición

                GameObject newBullet;

                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation); // Instanciamos un objeto en una posición y rotación específica

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce); // A nuestro objeto, le añadimos una fuerza en dirección hacia delante del spawnpoint y multiplicada por nuestra variable de fuerza

                shotRateTime = Time.time + shotRate; // Solo podemos disparar cada 0.5 segundos (shotRate)


                Destroy(newBullet, 5); // Cuando pasen 5 segundos la bala desaparece (evitamos problemas de rendimiento)

            }
        }
    }
}
