using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataform : MonoBehaviour
{
    public GameObject[] prefabsX;
    public GameObject[] prefabsZ;
    public Vector3 lastPlataform;
    public Transform firstPlataform;

    private void Start()
    {
        lastPlataform = firstPlataform.position;
    }
    void Update()
    {
        Time.timeScale = 0.2f;
        SpawnPlataformX();
    }

    public void SpawnPlataformX()
    {
        int random = Random.Range(0,4);
        Instantiate(prefabsX[random], new Vector3(0,0,0), Quaternion.identity);
      
    }
}
