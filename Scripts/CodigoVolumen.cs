using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodgioVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValues;
    public Image imagenMute;
    public Button muteButton; 

 
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        GameData.volumen=slider.value;
        AudioListener.volume = sliderValues;
        RevisarSiEstoyMute();

        // Asigna la función Mutear al botón de mute
        muteButton.onClick.AddListener(Mutear);
    }

    public void ChangeSlider(float valor)
    {
        sliderValues = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValues);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    public void Mutear()
    {
        sliderValues = 0f;
        slider.value = 0f;
        PlayerPrefs.SetFloat("volumenAudio", sliderValues);
        AudioListener.volume = 0f;
        RevisarSiEstoyMute();
    }

    private void RevisarSiEstoyMute()
    {
        if (sliderValues == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }
}
