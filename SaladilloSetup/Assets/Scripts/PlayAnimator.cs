//////////////////////
// Ramón Guardia
// Curso 2017-2018
// PlayAnimator.cs
/////////////////////

using UnityEngine;

public class PlayAnimator : MonoBehaviour
{
    // Tiempo que tardará en activarse el temporizador
    public float activationTime = 3f;

    // Indica si el puntero está sobre el objeto
    private bool isHover = false;

    // Indica si la acción se ha realizado
    private bool executed = false;

    //Objeto que contiene la animación
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        // Si el usuario está mirando el objeto y el temporizador
        // ha terminado de contrar o si el usuario está mirando el 
        // objeto y pulsa el botón fire1 del mando y la acción aun
        // no se ha ejecutado, realizaremos la acción correspondiente
        if ((isHover && CustomPointerTimer.CPT.ended && !executed) ||
            (isHover && Input.GetButtonDown("Fire1") && !executed))
        {
            // Se indica que se ha realizado la acción
            executed = true;
            // Desactivaremos el contadoe de tiempo del cursor, para
            // evitar que se quede bloqueado
            CustomPointerTimer.CPT.StopCounting();
            // Se lanza la animación
            player.GetComponent<Animator>().Play("ScrollDown");
        }
    }

    /// <summary>
    /// Método que llamaremos desde EventTrigger PointerEmter
    /// </summary>
    public void StartHover()
    {
        // Indicamos que el objeto está siendo mirado directamento
        isHover = true;
        // Marcamos la acción como no realizada
        executed = false;
        // Iniciamos el contador del puntero, indicádole el tiempo de activación
        CustomPointerTimer.CPT.StartCounting(activationTime);
    }

    /// <summary>
    /// Método que llamaremos desde el eventTrigger pointerexit
    /// </summary>
    public void EndHover()
    {
        // Indicamos que el objeto ya no está siendo mirado
        isHover = false;
        // Reiniciamos el contador del puntero
        CustomPointerTimer.CPT.StopCounting();
    }
}