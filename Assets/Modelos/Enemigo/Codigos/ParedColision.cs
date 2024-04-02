using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedColision : MonoBehaviour
{

    public float force = 100f;

    private void OnTriggerStay(Collider other)
    {
        // Si el personaje está dentro del trigger, lo empujamos
        if (other.gameObject.tag == "Caminata_con_modelo")
        {
            Vector3 direction = (transform.position - other.transform.position).normalized;
            other.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
        }
    }
}
