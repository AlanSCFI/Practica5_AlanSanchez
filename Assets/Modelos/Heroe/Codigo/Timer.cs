using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public float tiempoInicial = 300; // Tiempo inicial en segundos
    private float tiempoRestante; // Tiempo restante en segundos
    public event EventHandler pierdeJugador;

    public Text textoTimer;

    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    void Update()
    {
        // Restar el tiempo delta desde el temporizador
        tiempoRestante -= Time.deltaTime;

        // Actualizar el texto del temporizador
        textoTimer.text = FormatearTiempo(tiempoRestante);

        // Verificar si el temporizador ha llegado a cero
        if (tiempoRestante <= 0)
        {
            pierdeJugador?.Invoke(this, EventArgs.Empty);
            // Aquí puedes realizar cualquier acción cuando el temporizador llegue a cero
            Debug.Log("¡Tiempo terminado!");
        }
    }

    // Método para restablecer el temporizador a su valor inicial
    public void RestablecerTemporizador()
    {
        tiempoRestante = tiempoInicial;
    }

    // Método para formatear el tiempo en formato mm:ss
    private string FormatearTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        return string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}


