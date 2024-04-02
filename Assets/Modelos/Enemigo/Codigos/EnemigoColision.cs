using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemigoColision : MonoBehaviour
{
    public Transform user;
    private NavMeshAgent enemyAgent;
    private Animator enemyAnimator;
    public float detectionRadius = 10f;
    public float proximityThreshold = 2f; // Umbral de proximidad
    public float danioPorGolpe = 0.1f;
    public BarraDeVida barraDeVida;
    public float minimumDistance = 1f; // Distancia m�nima entre el enemigo y la c�mara para detener la navegaci�n
    public Image sangreEfecto;
    private float r;
    private float g;
    private float b;
    private float a;

    private bool isNavigationStopped = false;

    private void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();

        r = sangreEfecto.color.r;
        g = sangreEfecto.color.g;
        b = sangreEfecto.color.b;
        a = sangreEfecto.color.a;
    }

    private void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, user.position);

        // Si el jugador est� dentro del radio de detecci�n, sigue al jugador
        if (distanceToPlayer <= detectionRadius)
        {
            // Si la navegaci�n no est� detenida, establece el destino del enemigo
            if (!isNavigationStopped)
            {
                enemyAgent.destination = user.position;
                enemyAnimator.SetInteger("accion_enemigo", 1);
            }
        }
        else
        {
            // Si el jugador est� fuera del radio de detecci�n, det�n al enemigo
            enemyAgent.ResetPath(); // Detiene al enemigo
            enemyAnimator.SetInteger("accion_enemigo", 5); // Cambia la animaci�n a 5
        }

        // Calcula la distancia entre el enemigo y la c�mara
        float distanceToPlayerForProximity = Vector3.Distance(transform.position, user.position);

        // Si la distancia entre el enemigo y la c�mara es menor que el umbral de proximidad, establece accion_enemigo a 2
        if (distanceToPlayerForProximity <= proximityThreshold)
        {
            // Detener la navegaci�n si el enemigo est� demasiado cerca de la c�mara
            StopNavigation();
            enemyAnimator.SetInteger("accion_enemigo", 2);
            enemyAnimator.SetBool("isAttacking", true);
            // Reduce la vida del jugador cuando el enemigo ataca
            barraDeVida.ReducirVida(danioPorGolpe);
            a += 0.01f;

            a = Mathf.Clamp(a,0,1f);
            cambiaDeColor();
        }
        else
        {
            // Reanudar la navegaci�n si el enemigo est� lo suficientemente lejos de la c�mara
            ResumeNavigation();
            enemyAgent.destination = user.position;
            enemyAnimator.SetInteger("accion_enemigo", 1);
            enemyAnimator.SetBool("isAttacking", false);
            a -= 0.001f;
            a = Mathf.Clamp(a, 0, 1f);
            cambiaDeColor();
        }
    }

    private void cambiaDeColor()
    {
        Color c = new Color(r,g,b,a);
        sangreEfecto.color = c;
    }

    private void StopNavigation()
    {
        if (!isNavigationStopped)
        {
            enemyAgent.isStopped = true;
            isNavigationStopped = true;
        }
    }

    private void ResumeNavigation()
    {
        if (isNavigationStopped)
        {
            enemyAgent.isStopped = false;
            isNavigationStopped = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Cuando el jugador entra en el trigger del enemigo, activa la b�squeda del jugador
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Player entered detection radius");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Cuando el jugador sale del trigger del enemigo, detiene la b�squeda del jugador
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Player exited detection radius");
        }
    }
}







