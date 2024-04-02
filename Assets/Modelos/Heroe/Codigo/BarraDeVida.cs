using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BarraDeVida : MonoBehaviour
{
    public Image vida;
    public float vidaActual;
    public float vidaMaxima;
    public event EventHandler pierdeJugador;

    private void Start()
    {
        // Establecer la vida actual como igual a la vida máxima al inicio
        vidaActual = vidaMaxima;
    }

    void Update()
    {
        vida.fillAmount = vidaActual / vidaMaxima;
    }

    public void RestablecerVidaMaxima()
    {
        vidaActual = vidaMaxima;
    }

    // Método para reducir la vida del jugador
    public void ReducirVida(float cantidad)
    {
        // Restar la cantidad especificada a la vida actual
        vidaActual -= cantidad;

        // Asegurarse de que la vida no sea menor que 0
        vidaActual = Mathf.Clamp(vidaActual, 0f, vidaMaxima);

        // Actualizar la barra de vida
        vida.fillAmount = vidaActual / vidaMaxima;

        // Verificar si el jugador ha muerto
        if (vidaActual <= 0)
        {
            pierdeJugador?.Invoke(this, EventArgs.Empty);
            // Aquí puedes agregar código para manejar la muerte del jugador
            Debug.Log("¡El jugador ha muerto!");
        }
    }
}
