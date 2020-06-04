using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataform : MonoBehaviour
{
    public GameObject[] prefabsX; // Arrays que armazena os prefabas que vao no eixo X
    public GameObject[] prefabsZ; // Arrays que armazena os prefabas que vao no eixo Z
    public Vector3 lastPlataform; // Responsável por armazenar globalmente a posição da ultima plataforma criada
    public float PlataformScale; // Variavel auxliar que servira para determinar a posição da proxima plataforma, na logica dos metodos de criar as plataformas.

    private void Start()
    {
        lastPlataform = new Vector3(0, 0, 0);
        PlataformScale = prefabsX[0].transform.localScale.x;

        for (int i = 1; i < 40; i++)
        {
            SwitchPlataformXZ();
        }
    }
    void Update()
    {
//        Time.timeScale = 0.2f;
//        SpawnPlataformX();
    }

    public void SpawnPlataformX()
    {
        Vector3 positionPlataform = lastPlataform;   // Armazena a posição da ultima plataforma.
        int random = Random.Range(0, 4);

        positionPlataform.x += PlataformScale; // Gera a proxima posição se baseando na escala do eixo X, se estiver na posição 0,0,0 ela vai pegar o valor 1 do da escala  e a nova posição será 1,0,0
        lastPlataform = positionPlataform; // atualiza o valor da variavel global da ultima plataforma para as proximas chamadas.
        Instantiate(prefabsX[random], positionPlataform, Quaternion.identity);  // Cria a plataforma, na proxima posição, sem rotação.
    }

    public void SpawnPlataformZ()
    {
        Vector3 positionPlataform = lastPlataform; // O mesmo que SpawnPlataformX, apenas mudando a escala de X para Z
        int random = Random.Range(0, 4);

        positionPlataform.z += PlataformScale;
        lastPlataform = positionPlataform;
        Instantiate(prefabsX[random], positionPlataform, Quaternion.identity);
    }

    public void SwitchPlataformXZ()
    {
        int random = Random.Range(0, 7); // Gera valores aleatorios para qual plataforma criar.

        if (random <= 5)
        {
            SpawnPlataformX();
        }else
        {
            SpawnPlataformZ();
        }


    }
}
