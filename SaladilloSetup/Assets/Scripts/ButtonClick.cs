//////////////////////
// Ramón Guardia López
// Curso 2017-2018
// ButtonClick.cs
/////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    // GameObject que se modifica cuando se pulsa el boton
    public GameObject clickObject;
    
    /// <summary>
    /// Método que se ejecuta en el evento OnClick
    /// </summary>
    public void Click()
    {
        clickObject.SetActive(!clickObject.activeSelf);
    }
}