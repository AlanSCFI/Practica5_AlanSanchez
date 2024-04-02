using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraHeroe : MonoBehaviour
{
    public Transform target; // Transform del objeto "héroe"

    void Update()
    {
        // Posición de la cámara
        transform.position = target.position + Vector3.up * 0.5f; // Ajusta el offset para la altura de la cabeza

        // Rotación de la cámara
        transform.rotation = Quaternion.LookRotation(target.forward, Vector3.up);
    }
}
