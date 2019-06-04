﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController_Votaciones : MonoBehaviour
{

    public Text Txt_mecanica;
    public Text Txt_instruccion;
    public Text Txt_resultado;
    public GameObject Tiempo;
    public GameObject Inicio;
    public GameObject Controlers;
    private bool jugando = true;
    public int NumeroParaGanar;
    public int monitos;

    void Awake()
    {
        NumeroParaGanar = NumeroParaGanar + Vida.ResterTiempo;
    }

    void Start()
    {

        monitos = 0;
        Invoke("quitarInicio", 2);
       
        Invoke("quitarIntrucciones", 4);

    }


    void quitarInicio()
    {
        Inicio.SetActive(!Inicio.activeSelf);
    }
    private void Update()
    {
        if (monitos >= NumeroParaGanar)
        {
            if (jugando == true)
            {

                Ganaste();
            }
        }
    }
    //*********************************
    void quitarIntrucciones()
    {
        Txt_mecanica.text = "";
        Txt_instruccion.text = "";
        Tiempo.SetActive(!Tiempo.activeSelf);
        Controlers.SetActive(true);
    }

    public void Ganaste()
    {

        Tiempo.SetActive(false);
        Txt_resultado.text = "Ganaste";
        
        Invoke("escenaGanar", 1);
        
    }

    public void Perdiste()
    {
        jugando = false;
        Tiempo.SetActive(false);
        
        Tiempo.SetActive(!Tiempo.activeSelf);
        Txt_resultado.text = "Perdiste";
        Invoke("escenaPerder", 1);

    }


    public void escenaGanar()
    {
        AuidoScript.instance.Mute("Marcha");
        SceneManager.LoadScene("Sc_Ganar");
    }

    public void escenaPerder()
    {
        AuidoScript.instance.Mute("Marcha");
        SceneManager.LoadScene("Sc_Perder");
    }
    //**********************************

}