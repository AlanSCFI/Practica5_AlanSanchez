using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorDeCamara : MonoBehaviour
{
    Control Mando;
    Vector2 rotacion;
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;
    public float alturaFija = 1.5f; // Altura fija deseada de la c�mara

    private Rigidbody rb;
    private bool haColisionado = false;

    // L�mites de rotaci�n en los ejes X y Y
    public float maxRotacionX = 80f;
    public float minRotacionX = -80f;

    private void Awake()
    {
        Mando = new Control();

        Mando.Gameplay.Rotar.performed += ctx => rotacion = ctx.ReadValue<Vector2>();
        Mando.Gameplay.Rotar.canceled += ctx => rotacion = Vector2.zero;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Control de movimiento (joystick izquierdo)
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);

        // Obtener la rotaci�n actual
        Vector3 currentRotation = transform.localRotation.eulerAngles;

        // Calcular la rotaci�n vertical (eje X) limitando el �ngulo
        currentRotation.x = ClampRotation(currentRotation.x - rotacion.y * rotateSpeed * Time.deltaTime, minRotacionX, maxRotacionX);

        // Calcular la rotaci�n horizontal (eje Y)
        currentRotation.y += rotacion.x * rotateSpeed * Time.deltaTime;

        // Aplicar rotaciones
        transform.localRotation = Quaternion.Euler(currentRotation);

        // Mantener la altura fija
        Vector3 newPosition = transform.position;
        newPosition.y = alturaFija;
        transform.position = newPosition;

        // Si ha colisionado y la rotaci�n en el eje Z no es 0, restablecerla a 0
        if (haColisionado && transform.rotation.eulerAngles.z != 0)
        {
            currentRotation.z = 0f;
            transform.rotation = Quaternion.Euler(currentRotation);
        }

        // Control de movimiento
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        // Control de rotaci�n
        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.G))
        {
            transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        }
    }

    private float ClampRotation(float angle, float min, float max)
    {
        // Si el �ngulo es mayor que 180, restar 360 para obtener el rango correcto
        if (angle > 180f)
            angle -= 360f;

        // Clamp dentro del rango
        return Mathf.Clamp(angle, min, max);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si la c�mara colisiona con una pared, detener el movimiento y la rotaci�n
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pared"))
        {
            rb.velocity = Vector3.zero; // Detener cualquier velocidad actual
            rb.angularVelocity = Vector3.zero; // Detener cualquier rotaci�n actual
            haColisionado = true; // Marcar que ha colisionado
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Cuando se sale de la colisi�n con la pared, restablecer la marca de colisi�n
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pared"))
        {
            haColisionado = false;
        }
    }

    private void OnEnable()
    {
        Mando.Gameplay.Enable();
    }

    private void OnDisable()
    {
        Mando.Gameplay.Disable();
    }
}


