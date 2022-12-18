using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    private Quaternion startRotation; // Rotación inicial

    public float swayAmount = 8; // Cantidad de balanceo

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.localRotation; // La rotación inicial será la posición base de nuestro arma
    }

    // Update is called once per frame
    void Update()
    {
        Sway(); // Llamamos de forma constante a la función de balanceo
    }

    private void Sway() // Función de balanceo
    {
        // Creamos las variables con las posiciones del ratón
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Creamos las ángulos de rotación
        Quaternion xAngle = Quaternion.AngleAxis(mouseX * -1.25f, Vector3.up);
        Quaternion yAngle = Quaternion.AngleAxis(mouseX * 1.25f, Vector3.left);

        Quaternion targetRotation = startRotation * xAngle * yAngle; // Valor de la rotación modificada en cada momento

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * swayAmount); // Interpolamos las rotaciones y ajustamos el retardo de su movimiento con swayAmount
    }
}
