//using UnityEngine;
//using UnityEngine.AI;

//public class EnemigoAtaque : MonoBehaviour
//{
//    public float danioPorGolpe = 10f;
//    public BarraDeVida barraDeVida;
//    private Animator enemyAnimator;
//    public Transform user;
//    public float proximityThreshold = 2f; // Umbral de proximidad

//    private void Start()
//    {
//        // Buscar la barra de vida en la escena
//        barraDeVida = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BarraDeVida>();
//        // Obtener el componente Animator del enemigo
//        enemyAnimator = GetComponent<Animator>();
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        // Verificar si ha colisionado con el jugador
//        if (other.CompareTag("MainCamera"))
//        {
//            Debug.Log("El enemigo ha colisionado con el jugador");
//            float distanceToPlayerForProximity = Vector3.Distance(transform.position, user.position);

//            // Si el enemigo está atacando (animación 2), reduce la vida del jugador
//            if (distanceToPlayerForProximity <= proximityThreshold)
//            {
//                Debug.Log("El enemigo está atacando");
//                barraDeVida.ReducirVida(danioPorGolpe);
//            }
//            else
//            {
//                Debug.Log("El enemigo no está atacando");
//            }
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoAtaque : MonoBehaviour
{
    public float danioPorGolpe = 10f;
    public BarraDeVida barraDeVida;
    private Animator enemyAnimator;
    public Transform user;
    public float proximityThreshold = 2f; // Umbral de proximidad
    public Image golpeImagen; // Referencia a la imagen que se mostrará al recibir un golpe

    private void Start()
    {
        // Buscar la barra de vida en la escena
        barraDeVida = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BarraDeVida>();
        // Obtener el componente Animator del enemigo
        enemyAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si ha colisionado con el jugador
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("El enemigo ha colisionado con el jugador");
            float distanceToPlayerForProximity = Vector3.Distance(transform.position, user.position);

            // Si el enemigo está atacando (animación 2), reduce la vida del jugador
            if (distanceToPlayerForProximity <= proximityThreshold)
            {
                Debug.Log("El enemigo está atacando");
                barraDeVida.ReducirVida(danioPorGolpe);

                // Mostrar la imagen de golpe por medio segundo
                golpeImagen.gameObject.SetActive(true);
                StartCoroutine(OcultarImagenGolpe());
            }
            else
            {
                Debug.Log("El enemigo no está atacando");
            }
        }
    }

    IEnumerator OcultarImagenGolpe()
    {
        // Esperar medio segundo
        yield return new WaitForSeconds(0.5f);

        // Ocultar la imagen de golpe
        golpeImagen.gameObject.SetActive(false);
    }
}

