using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccionBotones : MonoBehaviour
{

    public void escenaPantallaPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
    public void escenaAjustes()
    {
        SceneManager.LoadScene("Ajustes");
    }

    public void escenaCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void escenaJuego()
    {
        SceneManager.LoadScene("Escena1");
    }

    public void quitarJuego()
    {
        Application.Quit();
    }
    

}
