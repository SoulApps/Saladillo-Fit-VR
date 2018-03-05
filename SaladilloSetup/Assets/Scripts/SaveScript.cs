//////////////////////
// Ramón Guardia
// Curso 2017-2018
// SaveScript.cs
/////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveScript : MonoBehaviour
{
    // Objeto con la dirección ip introducida por el usuario
    public Text ipAddress;

    // Objeto que indica que se ha establecido conexión;
    public GameObject connected;

    // Objeto que indica que se ha no establecido conexioón;
    public GameObject disconnected;

    // Objeto que representa al panel del cliente
    public GameObject clientPanel;

    /// <summary>
    /// Comprueba si existe conexión con la web API
    /// </summary>
    /// <remarks>
    /// LLamar a la corrutina CheckConnectivityWebApi para comprobar la conexión
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
            // hace la petición a la web api
            yield return www.SendWebRequest();

            // Comprueba el valor devuelto por el mótodo, activando el panel de cliente si la respuesta es positiva
            connected.SetActive(www.responseCode == 200);
            if (www.responseCode == 200)
            {
                // activamos el panel de cliente
                clientPanel.SetActive(true);
            }
            else
            {
                clientPanel.SetActive(false);
            }
            disconnected.SetActive(!connected.activeSelf);
        }
    }

    /// <summary>
    /// Método que se ejecuta cuando se pulsa el botón save.
    /// </summary>
    /// <remarks>
    /// Obtiene la dirección Ip introducidas por el usuario y la guarda en las preferencias de la aplicación.
    /// </remarks>
    public void Click()
    {
        // Se obtiene la direccion ip introducida por el usuario
        GameManager.ipAddress = ipAddress.GetComponent<Text>().text;
        // Se guarda la direccion Ip
        PlayerPrefs.SetString(GameManager.IP_ADDRESS, GameManager.ipAddress);
        // Se guarda el valor en la configuracion de la aplicación
        PlayerPrefs.Save();
        CheckConnectivity();
    }
}