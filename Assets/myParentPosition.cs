using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class myParentPosition : MonoBehaviour
{
    [SerializeField]
    Transform myParent;
    private void Start()
    {
        transform.SetParent(myParent);
    }
}