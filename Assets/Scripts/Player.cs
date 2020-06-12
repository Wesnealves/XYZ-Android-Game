using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    
    // Movimento e Pulo

    public float speedPlayer;
    public float jumpVelocity;

    // Android Inputs
    public Touch touch;
  


    private bool isMovingZ = false;
    private bool isMovingX = true;
    private bool canJump = true;

    
    Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
       
    }
    

    private void Update()
    {
        PlayerMove();
        PlayerJump(); // Funcionou melhor em Update do que em Fixed Update;
    }

    public void PlayerMove() // Movimento em eixous pelo teclado.
    {
        // Verificação de qual eixo irá se 'movimentar'.
        if (Input.GetKeyDown(KeyCode.X))
        {
            isMovingX = true;
            isMovingZ = false;
        }else if (Input.GetKeyDown(KeyCode.Z))
        {
            isMovingZ = true;
            isMovingX = false;
        }

        // Eixo que irá se movimentar.
        if (isMovingX)
        {
            this.transform.Translate(new Vector3(1, 0, 0) * speedPlayer * Time.deltaTime);
        }else if (isMovingZ)
        {
            this.transform.Translate(new Vector3(0, 0, 1) * speedPlayer * Time.deltaTime);
        }
    }

    public void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || touch.deltaPosition.y > 0 && isMovingX && canJump)
        {
            // Pula no eixo X
            canJump = false;
            playerRigidbody.AddForce(new Vector3(jumpVelocity / 2, jumpVelocity, 0) * jumpVelocity);
            touch.deltaPosition = new Vector2(0, 0);
            StartCoroutine(PlayerCanJump());
            

        }
        else if (Input.GetKeyDown(KeyCode.Space) || touch.deltaPosition.y > 0 && isMovingZ && canJump)
        {
            // Pula no eixo Z
            canJump = false;
            playerRigidbody.AddForce(new Vector3(0, jumpVelocity, jumpVelocity / 2) * jumpVelocity);
            touch.deltaPosition = new Vector2(0, 0);
            StartCoroutine(PlayerCanJump());
            
        }
    }

    IEnumerator PlayerCanJump()
    {
        yield return new WaitForSeconds(1f);
        canJump = true;

    }

}
