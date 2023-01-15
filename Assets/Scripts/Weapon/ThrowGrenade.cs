using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public float throwForce = 500;

    public GameObject grenadePrefab;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Cuando pulsemos la letra E
        {
            Throw(); // Llamamos al método que lanza la granada
        }


    }

    public void Throw()
    {
        GameObject newGrenade = Instantiate(grenadePrefab, transform.position, transform.rotation); // Instanciamos la granada en un punto y rotación
        newGrenade.GetComponent<Rigidbody>().AddForce(transform.forward*throwForce); // Cogemos el componente Rigidbody y le añadimos una fuerza hacia delante multiplicada por nuestra variable throwForce
    }
}
