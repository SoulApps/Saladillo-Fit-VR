//////////////////////
// Ramón Guardia
// Curso 2017-2018
// StartTrainingScript.cs
/////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class StartTrainingScript : MonoBehaviour {

	/// <summary>
	/// Este es el método que ejecuta el evento onClick
	/// </summary>
	public void Click()
	{
		// Llama al método que guarda la información del entrenamiento
		LogTraining();
	}
    
	/// <summary>
	/// Guarda la información del entrenamiento del cliente
	/// </summary>
	/// <remarks>
	/// Llama a una corrutina que conecta con la webApi para guardar la información.
	/// </remarks>
	private void LogTraining()
	{
		StartCoroutine(LogTrainingWebAPI());
	}

	private IEnumerator LogTrainingWebAPI()
	{
		// Construimos la información que se envía a la Web API
		WWWForm form = new WWWForm();
		form.AddField("dni", GameManager.clientDni);
		form.AddField("training", GameManager.training);
        
		// Crea la petición a la WebAPI
		using (UnityWebRequest www = UnityWebRequest.Post(
			Uri.EscapeUriString(string.Format(GameManager.WEB_API_LOG_TRAINING, GameManager.ipAddress)), form))
		{
			// Envía la petición a la web API y espera la respuesta
			yield return www.SendWebRequest();
			// Acción a realizar si la petición se ha realizado sin error
			if (!www.isNetworkError)
			{
				// Abrimos la actividad nueva
				SceneManager.LoadScene("Machines");
			}
		}
	}
}
