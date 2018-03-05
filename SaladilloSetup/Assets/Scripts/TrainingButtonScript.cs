//////////////////////
// Ramón Guardia
// Curso 2017-2018
// TrainingButtonScript.cs
/////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TrainingButtonScript : MonoBehaviour
{
    // Variable traning que indicará el valor del
    // enternamiento a escoger
    public int training;

    // Objeto que corresponde con el panel Detail
    public GameObject detailPanel;

    // Objeto que corresponde al prefab TrainingItem instanciado
    public GameObject trainingItem;

    /// <summary>
    /// Extrae los datos del entrenamiento que pasamos por parámetro.
    /// </summary>
    /// <remarks>
    /// Llama a la corrutina ObtainTrainingItemList para obtener los datos.
    /// </remarks>
    private void GetTrainingList()
    {
        StartCoroutine(ObtainTrainingItemList());
    }

    /// <summary>
    /// Obtiene la lista de TrainingItemList.
    /// </summary>
    /// <remarks>
    /// Instancia los datos en el panel de detail.
    /// </remarks>
    IEnumerator ObtainTrainingItemList()
    {
        // Prepara la petición
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeDataString(string.Format(GameManager.WEB_API_GET_TRAINING_LIST, GameManager.ipAddress,
                training))))
        {
            // hace la petición a la web api
            yield return www.SendWebRequest();

            // Acción a realizar si la petición se ha ejecutado sin error
            if (!www.isNetworkError)
            {
                // activamos el panel
                detailPanel.SetActive(true);
                // Se recupera la lista de entrenamientos
                TrainingList trainingList = JsonUtility.FromJson<TrainingList>(www.downloadHandler.text);
                // Se recorre la lista de entrenamientos
                for (int i = 0; i < trainingList.trainingItems.Length; i++)
                {
                    // Se crea el objeto para un trainingItem
                    GameObject trainingItem = Instantiate(this.trainingItem);
                    // Se asigna el texto que debe mostrar
                    trainingItem.GetComponentInChildren<Text>().text =
                        trainingList.trainingItems[i].name;
                    // Se establece su padre que esté en la escena
                    trainingItem.transform.SetParent(detailPanel.transform);
                    // Se posiciona en la escena
                    trainingItem.GetComponent<RectTransform>().localPosition = new Vector3(0, -0.13f * (i + 1), 0);
                }
            }
        }
    }

    /// <summary>
    /// Método que se ejecuta cuando se pulsa el botón.
    /// <remarks>
    /// Obtiene la lista de TrainingItems.
    /// </remarks>
    /// </summary>
    public void Click()
    {
        // Guardamos el número de entrenamiento
        GameManager.training = training;
        // Llamamos a la corrutina
        GetTrainingList();
    }


    #region Entidades

    public class TrainingList
    {
        public TrainingItem[] trainingItems;
    }

    [Serializable]
    public class TrainingItem
    {
        public string name;
    }

    #endregion
}