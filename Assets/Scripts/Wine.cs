using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wine : MonoBehaviour,IInteractable
{

    public string id; //Linha que o vinho estava
    public int type; //3 tipos diferentes de vinho


    /// <summary>
    ///Aqui fiz um vetor em que cada posição é um das propriedades que estarei mostrando, no caso:
    ///Posição 0: alcohol, sendo equivalente ao Eixo x
    ///Posição 1: malicAcid, sendo equivalente ao Eixo y
    ///Posição 2: ash, sendo equivalente ao Eixo z
    /// </summary>
    [SerializeField] public float[] prop = { 0.0f, 0.0f, 0.0f};

    /// <summary>
    /// Estou usando este se para fazer uma copia dos objetos vinho para serem armazenados nos gameObjects da scene
    /// </summary>
    /// <param name="targetId"></param>
    /// <param name="targetType"></param>
    /// <param name="targetProp"></param>
    public void setNameTypeProp(string targetId, int targetType, float[] targetProp)
    {
        id = targetId;
        type = targetType;
        prop = targetProp;
    }


    /// <summary>
    /// Void que implementa a interface de interactable
    /// </summary>
    public void Interact() 
    {
        Debug.Log("Vinho" + id + ": Tipo: " + type.ToString() + ",alcohol: " + prop[0].ToString() + ",malicAcid: " + prop[1].ToString() + ",ash: " + prop[2].ToString());
    }

}
