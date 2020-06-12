using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            Vector3 direcao = new Vector3(t.deltaPosition.x, t.position.y,0);


            if(t.phase == TouchPhase.Moved)
            {
                transform.Rotate(direcao * 1 * Time.deltaTime);
            }

        }
    }
}
