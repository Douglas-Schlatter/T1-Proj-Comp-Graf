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

        xRotation -= mouseY; //incluir a rotação no eixo y

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // dar um maximo de rotação em Y com clamp

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX); //Rotacionar de fato

        //Aqui estou pegando os inputs de movimentação
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Colocando esses inputs num vetor
        Vector3 move = transform.right*x+transform.forward*z;

        //Somando essas modificações ao vetor de posição do player
        playerBody.position += move * Time.deltaTime * movementSpeed;

        //Caso aperte barra de espaço suba
        if (Input.GetKey("space"))
        {
             playerBody.position += transform.up * Time.deltaTime * movementSpeed;
        }

        //Caso aperte shift desça
        if (Input.GetKey("left shift"))
        {
            playerBody.position -= transform.up * Time.deltaTime * movementSpeed;
        }



    }
}
