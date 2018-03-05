//////////////////////
// Ramón Guardia López
// Curso 2017-2018
// ConfigurationText.cs
/////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConfigurationText : MonoBehaviour
{
    // Objeto que indica que se ha establecido conexión;
    public GameObject connected;

    // Objeto que indica que se ha no establecido conexión;
    public GameObject disconnected;

    // Use this for initialization
    void Start()
    {
        // Se recupera el valor de dirección ip almacenado en la configuración de la aplicación
        GameManager.ipAddress = PlayerPrefs.GetString(GameManager.IP_ADDRESS);
        // Muestra la direccion ip
        GetComponent<Text>().text = GameManager.ipAddress;

        CheckConnectivity();
    }

    /// <summary>
    /// Comprueba si existe conexión con la web API.
    /// </summary>
    /// <remarks>
    /// LLamar a la corrutina CheckConnectivityWebApi para comprobar la conexión.
    /// </remarks>
    private void CheckConnectivity()
    {
        StartCoroutine(CheckConnectivityWebApi());
    }


    IEnumerator CheckConnectivityWebApi()
    {
        // Prepara la petición
        using (UnityWebRequest www =
            UnityWebRequest.Get(
                Uri.EscapeUriString(string.Format(GameManager.WEB_API_CHECK_CONNECTIVITY, GameManager.ipAddress))))
        {
            // hace la peticiópn a la web api
            yield return www.SendWebRequest();

            // Comprueba el valor devuelto por el método ,
            // si la respuesta es correcta activa la bola connected sino activa la esfera disconnted
            connected.SetActive(www.responseCode == 200);
            disconnected.SetActive(!connected.activeSelf);
        }
    }
}