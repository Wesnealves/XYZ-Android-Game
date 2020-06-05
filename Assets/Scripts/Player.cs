using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speedPlayer;
      public float jumpVelocity;
    Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        playerRigidbody.AddForce(new Vector3(speedPlayer,0,0) * Time.deltaTime, ForceMode.Impulse);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(new Vector3(jumpVelocity/2,jumpVelocity,0) * jumpVelocity);
        }

        



       
    }


}
