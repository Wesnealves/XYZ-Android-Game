using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataform : MonoBehaviour
{
    public GameObject[] prefabsX;
    public GameObject[] prefabsZ;
    public Vector3 lastPlataform;
    public float PlataformScale;

    private void Start()
    {
        lastPlataform = new Vector3(0, 0, 0);
        PlataformScale = prefabsX[0].transform.localScale.x;

        for (int i = 1; i < 20; i++)
        {
            SpawnPlataformX();
        }
    }
    void Update()
    {
//        Time.timeScale = 0.2f;
//        SpawnPlataformX();
    }

    public void SpawnPlataformX()
    {
        Vector3 positionPlataform = lastPlataform;
        int random = Random.Range(0, 4);

        positionPlataform.x += PlataformScale;
        lastPlataform = positionPlataform;
        Instantiate(prefabsX[random], positionPlataform, Quaternion.identity);
        
        
      
    }
}
