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
        // Após o Player sair da aréa Trigger, a plaforma comeca a receber influencia da gravidade, e depois é destruida.
        if (other.gameObject.CompareTag("Player"))
        {
            thisRigid.isKinematic = false;
            Destroy(this.gameObject, 2f);

        }
    }
}
