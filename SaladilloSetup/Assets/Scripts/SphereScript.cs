//////////////////////
// Ramón Guardia
// Curso 2017-2018
// SphereScript.cs
/////////////////////

using UnityEngine;

public class SphereScript : MonoBehaviour
{
    // Material de la sphere cuando no está siendo mirada
    public Material sphereMaterial;

    // Material de la sphere cuando esá siendo mirada
    public Material sphereHoverMaterial;

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material = sphereMaterial;
    }


    /// <summary>
    /// Método que se ejecuta cuando se empieza a mirar la sphere.
    /// <remarks>
    /// Cambia el material de la sphere al indicado que se debe mostrar cuanddo se mira la sphere.
    /// </remarks>
    /// </summary>
    public void HoveredSphere()
    {
        GetComponent<Renderer>().material = sphereHoverMaterial;
    }

    /// <summary>
    /// Método que se ejecuta cuando se deja de mirar la sphere.
    /// <remarks>
    /// Cambia el material de la sphere al indicado que se debe mostrar cuando se deja de mirar la sphere.
    /// </remarks>
    /// </summary>
    public void NotHoveredSphere()
    {
        GetComponent<Renderer>().material = sphereMaterial;
    }
}