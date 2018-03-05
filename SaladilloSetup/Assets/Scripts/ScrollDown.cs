//////////////////////
// Ramón Guardia
// Curso 2017-2018
// ScrollDown.cs
/////////////////////

using UnityEngine;

public class ScrollDown : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GetComponent<Animator>().Play("ScrollDown");
    }
}