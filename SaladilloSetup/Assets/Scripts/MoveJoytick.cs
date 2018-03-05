//////////////////////
// Ramón Guardia López
// Curso 2017-2018
// MoveJoystic.cs
/////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoytick : MonoBehaviour
{
    // Velocidad maxima de desplazamiento
    public float maxSpeed = 0.5f;

    // Fuerza de empuje
    public float pushForce = 10f;

    // Referencia al rigidbody que queremos mover
    public Rigidbody rigidbody;

    // Use this for initialization
    void Awake()
    {
        // Recuperamos la referencia al componente ridbody
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Recuperamos los valores de los ejes horizontal y vertical, son valores normalizados que van de 0 a 1
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // Calculamos el vector de movimiento con la dirección a la que mira la camara 
        Vector3 moveDirection = (h * Camera.main.transform.right + v * Camera.main.transform.forward).normalized;
        // comprobamos la magnitud  de desplazamiento y aplicamos el empuje si la velocidad máxima no se ha alcanzado
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            // Aplicamos el empuje en la dirección calculada con la fuerza indicada
            rigidbody.AddForce(moveDirection * pushForce);
        }
    }
}