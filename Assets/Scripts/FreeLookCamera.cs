using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{

    //Look rotation related
    [SerializeField] float mouseSens = 100f;
    [SerializeField] Transform playerBody;
    float xRotation = 0f;

    //Movement Related
    [SerializeField] float movementSpeed = 2.5f;
    void Start()
    {
        //Trave o mouse na tela
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY; //incluir a rota��o no eixo y

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // dar um maximo de rota��o em Y com clamp

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX); //Rotacionar de fato

        //Aqui estou pegando os inputs de movimenta��o
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Colocando esses inputs num vetor
        Vector3 move = transform.right*x+transform.forward*z;

        //Somando essas modifica��es ao vetor de posi��o do player
        playerBody.position += move * Time.deltaTime * movementSpeed;

        //Caso aperte barra de espa�o suba
        if (Input.GetKey("space"))
        {
             playerBody.position += transform.up * Time.deltaTime * movementSpeed;
        }

        //Caso aperte shift des�a
        if (Input.GetKey("left shift"))
        {
            playerBody.position -= transform.up * Time.deltaTime * movementSpeed;
        }



    }
}
