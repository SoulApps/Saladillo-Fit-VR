//////////////////////
// Ramón Guardia López
// Curso 2017-2018
// LoadButtonScript.cs
/////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadButtonScript : MonoBehaviour
{
    // Objeto donde se va a crear la información de los clientes
    public GameObject information;

    // Objeto que se crea para un clietne
    public GameObject client;

    /// <summary>
    /// Método que se ejecuta cuando se pulsa el botón Load.
    /// <remarks>
    /// Obtiene la lista de clientes.
    /// </remarks>
    /// </summary>
    public void Click()
    {
        GetClients();
    }

    /// <summary>
    /// Obtiene la lista de clientes.
    /// <remarks>
    /// Llama a una corrutina que conecta con la Web API para obtener información.
    /// </remarks>
    /// </summary>
    private void GetClients()
    {
        StartCoroutine(GetClientsWebAPI());
    }

    IEnumerator GetClientsWebAPI()
    {
        // Se crea la petición a la Web API 
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_CLIENTS, GameManager.ipAddress))))
        {
            // Envía la petición a la Web API y espera la respuesta
            yield return www.SendWebRequest();

            // Acción a realizar si la petición se ha ejecutado sin error
            if (!www.isNetworkError)
            {
                // Se recupera la lista de clientes
                ClientList clientList = JsonUtility.FromJson<ClientList>(www.downloadHandler.text);
                // Se recorre la lista de clientes
                for (int i = 0; i < clientList.clients.Length; i++)
                {
                    // Se crea el objeto para un cliente
                    GameObject clientItem = Instantiate(client);
                    // Se asigna el texto que debe mostrar
                    clientItem.GetComponentInChildren<Text>().text =
                        clientList.clients[i].dni + " - " + clientList.clients[i].name;
                    // Se establece su badre que esté en la escena
                    clientItem.transform.SetParent(information.transform);
                    // Se posiciona en la escena
                    clientItem.GetComponent<RectTransform>().localPosition = new Vector3(0, -0.13f * (i + 1), 0);
                }
            }
        }
    }


    #region Entidades
    /// <summary>
    /// Clase clientList
    /// </summary>
    public class ClientList
    {
        public Client[] clients;
    }
    /// <summary>
    /// Clase Client
    /// </summary>
    [Serializable]
    public class Client
    {
        public string dni;
        public string name;
    }

    #endregion
}