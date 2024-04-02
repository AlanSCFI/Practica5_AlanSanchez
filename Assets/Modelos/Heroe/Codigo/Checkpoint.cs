//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Checkpoint : MonoBehaviour
//{
//    // Posici�n y rotaci�n deseada del personaje al llegar al checkpoint
//    public Vector3 checkpointPosition = new Vector3(10.54f, 1f, -1.22f);
//    public Vector3 checkpointRotation = new Vector3(0f, -90f, 0f);


//    public BarraDeVida barraDeVida;

//    private void OnTriggerEnter(Collider other)
//    {
//        // Verificar si el objeto que entr� en el trigger es el personaje (c�mara)
//        if (other.CompareTag("MainCamera"))
//        {
//            // Restablecer la posici�n y rotaci�n del personaje al checkpoint
//            other.transform.position = checkpointPosition;
//            other.transform.rotation = Quaternion.Euler(checkpointRotation);

//            // Restablecer la barra de vida del jugador
//            if (barraDeVida != null)
//            {
//                barraDeVida.RestablecerVidaMaxima();
//            }
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    // Posici�n y rotaci�n deseada del personaje al llegar al checkpoint
    public Vector3 checkpointPosition = new Vector3(10.54f, 1f, -1.22f);
    public Vector3 checkpointRotation = new Vector3(0f, -90f, 0f);

    public Timer timer; // Referencia al script del temporizador

    public BarraDeVida barraDeVida;

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entr� en el trigger es el personaje (c�mara)
        if (other.CompareTag("MainCamera"))
        {
            // Restablecer la posici�n y rotaci�n del personaje al checkpoint
            other.transform.position = checkpointPosition;
            other.transform.rotation = Quaternion.Euler(checkpointRotation);

            // Restablecer la barra de vida del jugador
            if (barraDeVida != null)
            {
                barraDeVida.RestablecerVidaMaxima();
            }

            // Restablecer el temporizador a 300 segundos
            if (timer != null)
            {
                timer.RestablecerTemporizador();
            }
        }
    }
}


