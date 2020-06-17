using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerAndroid : MonoBehaviour
{

    

    [SerializeField]
    float speedPlayer = 0f;
    [SerializeField]
    private float forceJump = 0f;
    bool canJump;
    bool moveX;
    Touch touch;
    Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();

    }
    void Start()
    {
        canJump = true;
        moveX = false;
    }

   
    void Update()
    {
       PlayerAutoMove();
       TouchMove();
    }







    // ---------------------------------------------------------------------------------------------------------------------\

    // Movimento automatico do jogador pelo cenário.
    private void PlayerAutoMove()
    {
        this.transform.Translate(Vector3.right * speedPlayer * Time.deltaTime);
    }

    // Movimento horizontal do jogador através de 'Swipes' no touch.
    private void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);


            // Move no eixo Z Direita && Esquerda
            if (touch.phase == TouchPhase.Moved)
            {

                if (touch.deltaPosition.x < 0)
                {
                    transform.Translate(new Vector3(0, 0, 1) * 1f * Time.deltaTime);
                    moveX = true;
                    
                }
                else if (touch.deltaPosition.x > 0)
                {
                    transform.Translate(new Vector3(0, 0, -1) * 1f * Time.deltaTime);
                    moveX = true;
                }else
                {
                    moveX = false;
                }

                if (touch.deltaPosition.y > touch.deltaPosition.x && touch.deltaPosition.y >  50 && canJump)
                {
                    PlayerJump();

                }


            }

            

            
        }
    }
    // Pulo do jogador através de uma força aplicada nos eixos X e Y ao Rigidbody do jogador. Fazendo o saltar para e cair em forma de arco.
    private void PlayerJump()
    {
        
        playerRigidbody.AddForce(new Vector3(forceJump / 2, forceJump, 0) * forceJump);
        canJump = false;
        StartCoroutine(PlayerCanJump());


    }
   

    // Cronometro responsavel por limitar a quantidade de pulos do jogador por segundo.
    IEnumerator PlayerCanJump()
    {
        yield return new WaitForSeconds(1f);
        canJump = true;
    }

    // Faz o jogador pular obrigatoriamente ao chegar em uma aréa Trigger.
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Jump"))
        {
            if(touch.deltaPosition.y > 0)
            {
                PlayerJump();
                
            }

            
        }
    }


}
