using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = GameData.volumen;
    }


}
