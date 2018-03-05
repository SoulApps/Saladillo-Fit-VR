//////////////////////
// Ramón Guardia López
// Curso 2017-2018
// MoveJoystick.cs
/////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoystick : MonoBehaviour
{
    // Velocidad máxima de desplazamiento
    public float maxSpeed = 0.5f;

    // Fuerza de empuje
    public float pushForce = 10f;

    // Referencia al RigidBody que queremos mover
    public Rigidbody rigidbody;
    // Use this for initialization

    void Awake()
    {
        // Recuperamos la referencia al componente Rigybody
        rigidbody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Recuperamos el valor de los ejes horizontal y vertical
        // Son valores normalizados que van de 0 a 1
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Calculamos el vector de movimiento con la dirección a la que mira la cámara
        Vector3 moveDirection = (h * Camera.main.transform.right + v * Camera.main.transform.forward).normalized;
        // Comprobamos la magnitud de desplazamiento y aplicamos el empuje si la velocidad
        // máxima no se ha alcanzado
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            // Aplicamos el empuje de la dirección calculada con la fuerza indicada
            rigidbody.AddForce(moveDirection * pushForce);
        }
    }
}