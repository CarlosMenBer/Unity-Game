using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;
public static class controladorDatosJuego
{
    //public controladorDatosJuego instance;

    //private Movimiento movimiento;

    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }

    //    // Obtén la referencia al componente Movimiento
    //    movimiento = GameObject.FindObjectOfType<Movimiento>();
    //}

    public static void guardar()
    {
        DatosJugador datos = new DatosJugador();

        datos.vida = GameData.vida;
        datos.llaveAzul = GameData.llaveAzul;
        datos.llaveAmarilla = GameData.llaveAmarilla;
        datos.llaveVerde = GameData.llaveVerde;
        datos.llaveRoja = GameData.llaveRoja;

        Debug.Log("Datos del jugador: vida=" + datos.vida +
                  ", llaveAzul=" + datos.llaveAzul +
                  ", llaveAmarilla=" + datos.llaveAmarilla +
                  ", llaveVerde=" + datos.llaveVerde +
                  ", llaveRoja=" + datos.llaveRoja);

        string carpeta = "GuardarDatos";
        string filePath = Path.Combine(Application.dataPath, carpeta, "Datosjugador.json");

        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Debug.Log("Hemos creado un fichero.json");
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        string json = JsonUtility.ToJson(datos);
        File.WriteAllText(filePath, json);
        Debug.Log("Datos guardados en: " + filePath);
    }

    public static void cargarDatos()
    {
        string carpeta = "GuardarDatos";
        string filePath = Path.Combine(Application.dataPath, carpeta, "Datosjugador.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            DatosJugador datos = JsonUtility.FromJson<DatosJugador>(json);

            Debug.Log("Datos del jugador: vida=" + datos.vida +
                      ", llaveAzul=" + datos.llaveAzul +
                      ", llaveAmarilla=" + datos.llaveAmarilla +
                      ", llaveVerde=" + datos.llaveVerde +
                      ", llaveRoja=" + datos.llaveRoja);

            GameData.vida = datos.vida;
            GameData.llaveAzul = datos.llaveAzul;
            GameData.llaveAmarilla = datos.llaveAmarilla;
            GameData.llaveVerde = datos.llaveVerde;
            GameData.llaveRoja = datos.llaveRoja;

            Debug.Log("Valores después de asignar a movimiento: vida=" + GameData.vida +
                      ", llaveAzul=" + GameData.llaveAzul +
                      ", llaveAmarilla=" + GameData.llaveAmarilla +
                      ", llaveVerde=" + GameData.llaveVerde +
                      ", llaveRoja=" + GameData.llaveRoja);
        }
        else
        {
            guardar();
            Debug.Log("Archivo JSON no encontrado. Creando uno nuevo con datos por defecto.");
        }

    }

    public static void IniciarNuevaPartida()
    {
        DatosJugador datos = new DatosJugador();
        datos.vida = 6;
        datos.llaveAzul = false;
        datos.llaveAmarilla = false;
        datos.llaveVerde = false;
        datos.llaveRoja = false;

        string carpeta = "GuardarDatos";
        string filePath = Path.Combine(Application.dataPath, carpeta, "Datosjugador.json");

        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Debug.Log("Hemos creado un fichero.json");
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        string json = JsonUtility.ToJson(datos);
        File.WriteAllText(filePath, json);
        Debug.Log("Datos guardados en: " + filePath);

    }


}
