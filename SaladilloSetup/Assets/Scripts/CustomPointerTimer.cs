//////////////////////
// Ramón Guardia López
// Curso 2017-2018
// CustomPointerTimer.cs
/////////////////////

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class CustomPointerTimer : MonoBehaviour
{
    // Objeto compartido por todos los scripts
    public static CustomPointerTimer CPT;

    // Tiempo por defecto que vamos a tener que espera para que el contador se rellene
    private float timeToWait = 3f;

    // Temporizador
    private float timer = 0f;

    // componente Image de la image de relleno
    private Image image;

    // Indica cuando esta contando
    [HideInInspector] public bool counting = false;

    // Indica si ha llegado al final
    [HideInInspector] public bool ended = false;

    // Use this for initialization(Se invoca antes que el start)
    private void Awake()
    {
        if (CPT == null)
        {
            // Se obtiene el objeto temporizador
            CPT = GetComponent<CustomPointerTimer>();
        }

        // Se obtiene la imagen del reloj
        image = GetComponentInChildren<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            // Se incrementa el temporizador la porción de tiempo
            // que ha tardado em rederizar el íltimo update. De esta
            // manera se tiene un control de tiempo real independientemente
            // de las carateríticas de máquina
            timer += Time.deltaTime;
            // Se rellena la imagem ña camtidad proporcional al temporizador
            image.fillAmount = timer / timeToWait;
        }
        else
        {
            // se reinicia el temporizador
            timer = 0f;
            // Se reinicia el relleno
            image.fillAmount = timer;
        }

        // Se comprueba si ha cumplido el tiempo de espera
        if (timer >= timeToWait)
        {
            // se indica que el contador ha finalizado
            ended = true;
        }
    }

    /// <summary>
    /// Inicia el temporizador, utilizando el tiempo indicado como parámetro.
    /// </summary>
    /// <param name="time"></param>
    public void StartCounting(float time)
    {
        counting = true;
        ended = false;
        timeToWait = time;
    }

    public void StopCounting()
    {
        counting = false;
        ended = true;
    }
}