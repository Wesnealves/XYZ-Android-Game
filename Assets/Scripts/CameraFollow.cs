using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target; // Define quem será o alvo da camera, no caso, o player.
    private Vector3 distance; 

    void Start()
    {
        distance = this.transform.position - target.transform.position; // Armazena a distancia entre a camera e o player.
    }
    private void LateUpdate()
    {
        this.transform.position = target.transform.position + distance; // Locomove a camera de acordo com a posicao do Player mantendo a mesma distancia.
    }
}
