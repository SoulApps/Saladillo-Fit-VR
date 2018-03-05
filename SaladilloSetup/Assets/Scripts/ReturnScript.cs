//////////////////////
// Ramón Guardia
// Curso 2017-2018
// ReturnScript.cs
/////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    /// <summary>
    /// Método que se ejecutará en el evento OnClick
    /// </summary>
    public void Click()
    {
        SceneManager.LoadScene("Main");
    }
}