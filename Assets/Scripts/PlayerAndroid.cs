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
    bool canJump = true;
    bool moveX = false;
    Touch touch;
    Rigidbody playerRigidbody;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        PlayerAutoMove();
        TouchMove();
    }

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
                    transform.Translate(new Vector3(0, 0, 1) * 2.5f * Time.deltaTime);
                    moveX = true;
                    
                }
                else if (touch.deltaPosition.x > 0)
                {
                    transform.Translate(new Vector3(0, 0, -1) * 2.5f * Time.deltaTime);
                    moveX = true;
                }else
                {
                    moveX = false;
                }

                if (touch.deltaPosition.y > 50 && canJump)
                {
                    PlayerJump();

                }


            }

            

            
        }
    }

    private void PlayerJump()
    {
        
        playerRigidbody.AddForce(new Vector3(forceJump / 2, forceJump, 0) * forceJump);
        canJump = false;
        StartCoroutine(PlayerCanJump());


    }
   

    IEnumerator PlayerCanJump()
    {
        yield return new WaitForSeconds(1f);
        canJump = true;
    }
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
