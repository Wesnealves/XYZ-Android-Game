using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public GameObject target; // Define quem será o alvo da camera, no caso, o player.
    private Vector3 distance;
    public PlayerAndroid player;
    [SerializeField]
    GameObject texto;
    void Start()
    {
        distance = this.transform.position - target.transform.position; // Armazena a distancia entre a camera e o player.
        
        
    }

    private void Update()
    {

        if (player.GameStart)
        {
            this.transform.Translate(Vector3.forward * player.speedPlayer * Time.deltaTime);
        }
    }
    
    public void Segue()
    {
        if (target != null)
        {
            this.transform.position = target.transform.position + distance; // Locomove a camera de acordo com a posicao do Player mantendo a mesma distancia.
        }
        else
        {
            texto.SetActive(true);
        }

    }

}

// Nota: Quando criar a classe UIManager, lembrar de instaciar a tela de morte através da classe e não pela Camera;

 