
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeMaterial : MonoBehaviour
{
    public Material[] myMaterial; // Array que irá conter os Materials.
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player")) 
        {
            foreach(GameObject plataforma in GameObject.FindGameObjectsWithTag("Ground")) // Para cada objeto plataforma, acessa o material do MeshRender do objeto plataforma, e trocar para um material do array;
            {
                plataforma.gameObject.GetComponent<MeshRenderer>().material = myMaterial[1];
               
            }
            Destroy(this.gameObject);
        }

        
    }
}
