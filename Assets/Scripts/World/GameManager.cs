using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text ammoText;

    public static GameManager Instance { get; private set;}

    public int gunAmmo = 10;

    public Text healthText;

    public int health = 100;

    public int maxHealth = 100;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ammoText.text = gunAmmo.ToString(); // Convertimos el número de munición a una cadena de texto y la asignamos a ammoText para que se muestre en la UI
        healthText.text = health.ToString(); // Convertimos la vida a una cadena de texto y la asignamos a healthText para que se muestre en la UI
    }

    public void LoseHealth(int healthToReduce)
    {
        health -= healthToReduce;
        CheckHealth();
    }

    public void CheckHealth()
    {
        if (health <= 0) // Si la vida llega a 0
        {
            Debug.Log("Has muerto");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddHealth(int health)
    {
        if (this.health + health >= maxHealth)
        {
            this.health = 100;
        }
        else
        {
            this.health += health;
        }
    }
}
