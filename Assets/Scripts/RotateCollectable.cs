using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCollectable : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(new Vector3(0,-1,0) * 5f);
    }
}
