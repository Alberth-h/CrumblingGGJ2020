﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotacionEscenario : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0.3f,0));
    }

    public void CargaNivel (string pNombreNivel) {
        SceneManager.LoadScene (pNombreNivel);
    }

    public void SalirJuego(){

        Debug.Log ("Has salido del juego!");
        Application.Quit();
    }
}