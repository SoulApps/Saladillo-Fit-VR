//////////////////////
// Ramón Guardia López
// Curso 2017-2018
// ClientButtonScript.cs
/////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ClientButtonScript : MonoBehaviour {
    
    /// <summary>
    /// Este es el método que ejecuta el evento onClick
    /// </summary>
    public void Click()
    {
        // Llama al método que guarda la información del cliente
        LogClient();
    }
    
    /// <summary>
    /// Guarda la información del cliente del cliente 
    /// </summary>
    /// <remarks>
    /// Llama a una corrutina que conecta con la webApi para guardar la información.
    /// </remarks>
    private void LogClient()
    {
        StartCoroutine(LogClientWebAPI());
    }

    private IEnumerator LogClientWebAPI()
    {
        // Construimos la información que se envía a la Web API
        WWWForm form = new WWWForm();
        form.AddField("dni", GetComponentInChildren<Text>().text.Split('-')[0].Trim());
        form.AddField("name", GetComponentInChildren<Text>().text.Split('-')[1].Trim());
        
        // Crea la petición a la WebAPI
        using (UnityWebRequest www = UnityWebRequest.Post(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_LOG_CLIENT, GameManager.ipAddress)), form))
        {
            // Envía la petición a la web API y espera la respuesta
            yield return www.SendWebRequest();
            // Acción a realizar si la petición se ha realizado sin error
            if (!www.isNetworkError)
            {
                // Se llama al audiosource del padre y se ejecuta
                GetComponentInParent<AudioSource>().Play();
            }
        }
    }
}
