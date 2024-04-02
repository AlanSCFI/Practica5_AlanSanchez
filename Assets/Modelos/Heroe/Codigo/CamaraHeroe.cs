using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraHeroe : MonoBehaviour
{
    public Transform target; // Transform del objeto "h�roe"

    void Update()
    {
        // Posici�n de la c�mara
        transform.position = target.position + Vector3.up * 0.5f; // Ajusta el offset para la altura de la cabeza

        // Rotaci�n de la c�mara
        transform.rotation = Quaternion.LookRotation(target.forward, Vector3.up);
    }
}
