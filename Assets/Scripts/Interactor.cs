using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Essa � a minha parte a mais da entrega, quero fazer um sistema de intera��o com o usuario que
 ao apertar "e" possa ter os dados escritos no console
 */
/// <summary>
/// Tudo que for interagivel (No caso desse trabalho s�o os vinhos)
/// Ter� que possuir um void de intera��o
/// </summary>
interface IInteractable {
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteracRange;

        

    // Update is called once per frame
    void Update()
    {

        //Se a tecla e for pressionada
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Fa�a um raycast
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            //Se o raio retornar algo,coloque esse algo em hitinfo
            if (Physics.Raycast(r,out RaycastHit hitInfo,InteracRange))
            {

                //Tente pegar algo que seja da interface em interagivel
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    //Chame a fun��o de intera��o daquele objeto
                    interactObj.Interact();
                }
            }
        }
    }
}
