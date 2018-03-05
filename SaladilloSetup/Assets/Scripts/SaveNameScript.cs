//////////////////////
// Ramón Guardia
// Curso 2017-2018
// SaveNameScript.cs
/////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveNameScript : MonoBehaviour
{
    // Objeto que representa al texto del dni
    public Text clientDNIText;

    //  Objeto que representa al texto del mensaje inicial
    public Text initialMessage;

    // Objeto que representa al panel de training
    public GameObject trainingPanel;

    // Objeto que representa al texto de inicio del cliente
    public Text clientTextName;

    /// <summary>
    /// Comprueba si existe el nombre al introducir el usuario
    /// </summary>
    /// <remarks>
    /// LLamar a la corrutina CheckConnectivityWebApi para comprobar la conexión
    /// </remarks>
    private void GetName()
    {
        StartCoroutine(GetClientByDNI());
    }

    IEnumerator GetClientByDNI()
    {
        // Prepara la petición
        using (UnityWebRequest www =
            UnityWebRequest.Get(
                Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_CLIENT_BY_DNI, GameManager.ipAddress,
                    GameManager.clientDni))))
        {
            // hace la petición a la web api
            yield return www.SendWebRequest();

            // Comprueba el valor devuelto por el metodo , si la respuesta es correcta hacemos la segunda pregunta
            // Acción a realizar si la petición se ha realizado sin error
            if (!www.isNetworkError)
            {
                // Recuperamos el nombre
                GameManager.clientName = www.downloadHandler.text.Replace('"', ' ').Trim();
                // ponemos ese nombre al texto
                initialMessage.text = string.Format("Bienvenido {0}", GameManager.clientName);
                trainingPanel.SetActive(true);
                clientTextName.text = GameManager.clientName;
            }
            else
            {
                initialMessage.text = "Bienvenido/@ a Saladillo FIT VR";
                trainingPanel.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Método que se ejecuta cuando se pulsa el boton save.
    /// </summary>
    /// <remarks>
    /// Obtiene el DNI y lo usa para comprobar
    /// </remarks>
    public void Click()
    {
        // Se obtiene el dni introducido por el usuario
        GameManager.clientDni = clientDNIText.text;
        // comprobamos el nombre
        GetName();
    }
}