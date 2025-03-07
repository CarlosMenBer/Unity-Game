using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;
public class Movimiento : MonoBehaviour
{
    // Puerta y LLaves
    GameObject PuertaAzul, PuertaAmarilla, PuertaVerde, PuertaRoja;
    GameObject LLaveAzul, LLaveAmarilla, LLaveVerde, LLaveRoja;

    void Awake()
    {

        // Inicializa las referencias en Awake
        PuertaAzul = GameObject.FindWithTag("PuertaAzul");
        PuertaAmarilla = GameObject.FindWithTag("PuertaAmarilla");
        PuertaVerde = GameObject.FindWithTag("PuertaVerde");
        PuertaRoja = GameObject.FindWithTag("PuertaRoja");

        LLaveAzul = GameObject.FindWithTag("llaveNormalAzul");
        LLaveAmarilla = GameObject.FindWithTag("llaveNormal");
        LLaveVerde = GameObject.FindWithTag("llaveNormalVerde");
        LLaveRoja = GameObject.FindWithTag("llaveNormalRoja");
    }

    private void Start()
    {
        controladorDatosJuego.cargarDatos();

        if (GameData.llaveVerde)
        {
            Destroy(LLaveVerde);
        }

        if (GameData.llaveRoja)
        {
            Destroy(LLaveRoja);
        }

        if (GameData.llaveAmarilla)
        {
            Destroy(LLaveAmarilla);
        }

        if (GameData.llaveAzul)
        {
            Destroy(LLaveAzul);
        }
    }
    void Update() { 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 
        Vector3 movement = new Vector3(horizontal, vertical, 0);
        transform.position += movement * GameData.moveSpeed * Time.deltaTime;
        if (GameData.llaveAzul) 
        { 
            Destroy(PuertaAzul);
        }
        if (GameData.llaveAmarilla) 
        {
            Destroy(PuertaAmarilla);
        }
        if (GameData.llaveRoja) 
        {
            Destroy(PuertaRoja);
        } 
        if (GameData.llaveVerde) 
        { 
            Destroy(PuertaVerde); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemigo")
        {
            GameData.vida--;

            if (GameData.vida <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (collision.gameObject.tag == "salida")
        {
            SceneManager.LoadScene("EscenaFinal");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "llaveNormalAzul")
        {
            GameData.llaveAzul = true;
            Destroy(LLaveAzul);
        }

        if (collision.gameObject.tag == "llaveNormal")
        {
            GameData.llaveAmarilla = true;
            Destroy(LLaveAmarilla);
        }

        if (collision.gameObject.tag == "llaveNormalVerde")
        {
            GameData.llaveVerde = true;
            Destroy(LLaveVerde);
        }

        if (collision.gameObject.tag == "llaveNormalRoja")
        {
            GameData.llaveRoja = true;
            Destroy(LLaveRoja);
        }
    }
}


