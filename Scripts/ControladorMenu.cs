using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject MenuPause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        MenuPause.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
        isPaused = true;
    }

    public void ResumeGame()
    {
        MenuPause.SetActive(false);
        Time.timeScale = 1f; // Reanuda el juego
        isPaused = false;
    }

    public void SalirJuego()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GuardarDatos()
    {
        controladorDatosJuego.guardar();
    }

    public void CargarDatos()
    {
        controladorDatosJuego.cargarDatos();
    }

    public void IniciarNuevaPartida()
    {
        controladorDatosJuego.IniciarNuevaPartida();
    }
}
