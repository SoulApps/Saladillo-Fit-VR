//////////////////////
// Ramón Guardia López
// Curso 2017-2018
// MovementScript.cs
/////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Velocidad maxima de desplazamiento
    public float maxSpeed = 0.5f;

    // Fuerza de empuje
    public float pushForce = 10f;

    // Indicar si el usuario esta mirando directamente al disco
    [HideInInspector]
    public bool isHover = false;
    // Referencia al rigidbody que queremos mover
    public Rigidbody rigidbody;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isHover)
        {
            if (rigidbody.velocity.magnitude < maxSpeed)
            {
                rigidbody.AddForce((GvrPointerInputModule.Pointer.CurrentRaycastResult.worldPosition-transform.position).normalized*pushForce);
            }
        }
        
    }

    /// <summary>
    /// Acciones a realizar para el evento de mirar el disco.
    /// </summary>
    public void StartLookingAtDisc()
    {
        isHover = true;
    }
    /// <summary>
    /// Acciones a realizar para el evento de dejar de mirar el disco
    /// </summary>
    public void StopLookingAtDisc()
    {
        isHover = false;
    }
}