using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarSiguienteEscena : MonoBehaviour
{

    void Update()
    {
        // Si se detecta cualquier pulsaci�n de tecla o bot�n
        if (Input.anyKeyDown)
        {
            // Cargar la siguiente escena
            SceneManager.LoadScene("Menu");
        }
    }
}
