using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamaraControlAlternativo : MonoBehaviour
//{
//    CharacterController characterController;

//    public float walkSpeed = 6.0f;
//    public float runSpeed = 10.0f;
//    public float gravity = 20.0f;

//    private Vector3 move = Vector3.zero;

//    // Start is called before the first frame update
//    void Start()
//    {
//        characterController = GetComponent<CharacterController>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (characterController.isGrounded) 
//        {
//            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")); 

//            if (Input.GetKey(KeyCode.LeftShift))
//                move = transform.TransformDirection(move) * runSpeed;
//            else
//                move = transform.TransformDirection(move) * walkSpeed;

//        }

//        //move.y -= gravity * Time.deltaTime;

//        characterController.Move(move * Time.deltaTime);
//    }
//}

//{
//    public float velocidadMovimiento = 10f;
//    public float sensibilidadRotacion = 100f;

//    private void Update()
//    {
//        // Movimiento de la cámara (joystick izquierdo)
//        Vector3 movimiento = new Vector3(Input.GetAxis("LeftStickHorizontal"), 0f, Input.GetAxis("LeftStickVertical"));
//        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime);

//        // Rotación de la cámara (joystick derecho)
//        Vector3 rotacion = new Vector3(Input.GetAxis("RightStickHorizontal"), Input.GetAxis("RightStickVertical")) * sensibilidadRotacion * Time.deltaTime;
//        transform.Rotate(rotacion);
//    }
//}

{
    public float velocidadMovimiento = 10f;
    public float sensibilidadRotacion = 100f;

    private Vector3 rotacionActual;

    private void Update()
    {
        // Movimiento de la cámara (joystick izquierdo)
        Vector3 movimiento = new Vector3(Input.GetAxis("LeftStickHorizontal"), 0f, Input.GetAxis("LeftStickVertical"));
        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime);

        // Almacenar la rotación actual
        rotacionActual = transform.rotation.eulerAngles;

        // Rotación de la cámara (joystick derecho)
        Vector3 rotacionInput = new Vector3(Input.GetAxis("RightStickHorizontal"), Input.GetAxis("RightStickVertical"));

        // Solo si hay movimiento en el joystick derecho
        if (rotacionInput.sqrMagnitude > 0.01f)
        {
            Vector3 rotacion = rotacionInput * sensibilidadRotacion * Time.deltaTime;
            transform.Rotate(rotacion);
        }
    }
}
