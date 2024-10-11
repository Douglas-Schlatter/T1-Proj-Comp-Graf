using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Plotter : MonoBehaviour
{
    //File Related
    private string filePath;
    private int currentLineIndex = 1;
    public string[] lines;
    private string[] sections;


    //Wine Related
    public int wineIndex = 0;
    public List<Wine> wines = new List<Wine>();
    public int quantWine;
    public Wine currentW;
    public GameObject winePrefab;

    //Axis Related
    [SerializeField] public float[] propMax = { 0.0f, 0.0f, 0.0f };
    public GameObject axisPrefab;



    void Start()
    {

        filePath = Application.streamingAssetsPath + "/wineNotComma.csv";
        lines = File.ReadAllLines(filePath);

        //Para cada linha crie um objecto vinho que armazenará id,tipo e propriedades
        while (currentLineIndex < lines.Length)
        {
            Wine wInter = new Wine();
            wInter.id = currentLineIndex.ToString();
            sections = lines[currentLineIndex].Split(";");
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    wInter.type = int.Parse(sections[i]);
                }
                else
                {

                    wInter.prop[i - 1] = float.Parse(sections[i]);
                    if (propMax[i - 1] < wInter.prop[i - 1])
                    {
                        propMax[i - 1] = wInter.prop[i - 1];
                    }
                }
            }
            wines.Add(wInter);
            currentLineIndex++;

        }
        // Aqui estou intanciando cada vinho
        foreach (Wine w in wines)
        {
            Vector3 spot = new Vector3(w.prop[0], w.prop[1], w.prop[2]);

            GameObject target = Instantiate(winePrefab, spot, winePrefab.transform.rotation);
            target.name = w.id;
            target.AddComponent<Wine>().setNameTypeProp(w.id,w.type, w.prop); //Usar isso para depois fazer um sistema de interação com o usuario que exibe as informações com eventos
            //Mude a cor do vinho de acordo com o tipo
            switch (w.type)
            {
                case 1:
                    target.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 2:
                    target.GetComponent<Renderer>().material.color = Color.green;
                    break;
                default:
                    target.GetComponent<Renderer>().material.color = Color.blue;
                    break;
            }

        }
        //Aqui estou instanciando os eixos de acordo com os valores maximos em cada eixo
        for (int i = 0; i < 3; i++)
        {
            GameObject target = Instantiate(axisPrefab, axisPrefab.transform.position, winePrefab.transform.rotation);
            switch (i)
            {
                case 0:
                    target.transform.localScale = new Vector3(propMax[i], target.transform.localScale.y, target.transform.localScale.z);
                    target.transform.position += new Vector3(propMax[i] / 2, 0, 0);
                    target.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 1:
                    target.transform.localScale = new Vector3( target.transform.localScale.x, propMax[i], target.transform.localScale.z);
                    target.transform.position += new Vector3( 0, propMax[i] / 2, 0);
                    target.GetComponent<Renderer>().material.color = Color.green;
                    break;
                default: // Ou seja = 2
                    target.transform.localScale = new Vector3( target.transform.localScale.x, target.transform.localScale.y, propMax[i]);
                    target.transform.position += new Vector3(0, 0, propMax[i] / 2);
                    target.GetComponent<Renderer>().material.color = Color.blue;
                    break;
            }
            
        }
    }
    
}
