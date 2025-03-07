using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarraVida : MonoBehaviour
{
    public Image rellenoBarraVida;
    private Movimiento playerController;
    private float vidaMaxima;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<Movimiento>();
        // vidaMaxima = playerController.vida;
        vidaMaxima = GameData.vida;
    }

    // Update is called once per frame
    void Update()
    {
    rellenoBarraVida.fillAmount = GameData.vida / vidaMaxima;
    }
}
