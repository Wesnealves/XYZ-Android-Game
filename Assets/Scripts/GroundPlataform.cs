using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundPlataform : MonoBehaviour
{
    public Rigidbody thisRigid;
    void Start()
    {
        thisRigid = GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thisRigid.isKinematic = false;
            Destroy(this.gameObject, 2f);

        }
    }
}
