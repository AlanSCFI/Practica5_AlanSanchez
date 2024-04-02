using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    private BarraDeVida barraDeVida;
    private Timer timer;

    private void Start()
    {
        barraDeVida = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BarraDeVida>();
        barraDeVida.pierdeJugador += ActivarMenu;
        
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        timer.pierdeJugador += ActivarMenu;
    }

    private void ActivarMenu(object sender, EventArgs e)
    {
        gameOver.SetActive(true);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //public void Salir()
    //{
    //    UnityEditor.EditorApplication.isPlaying = false;
    //    Application.Quit();
    //}

}
