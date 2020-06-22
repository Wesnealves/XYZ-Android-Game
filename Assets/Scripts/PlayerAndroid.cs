using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


[RequireComponent(typeof(Rigidbody))]
public class PlayerAndroid : MonoBehaviour
{
    public GameObject explosion;
    public bool GameStart = false;
    [SerializeField]
    public float speedPlayer = 0f;
    [SerializeField]
    private float forceJump = 0f;
    bool canJump;
    bool canMoveRight = true;
    bool canMoveLeft = true;

    Touch touch;
    [SerializeField]
    InvisibleJoystick playerJoystick;
    Vector3 dir;
    

    Rigidbody playerRigidbody;
    [SerializeField]
    Animator playerAnimator;
    [SerializeField]
    UIManager uiManager;
    [SerializeField]
    private AudioSource musicBackground;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
        uiManager = GameObject.Find("Camera").GetComponent<UIManager>();

    }
    void Start()
    {
        canJump = true;
       
    }

   
    void Update()
    {

      PlayerAutoMove();
      TouchMove();
      MoveD();
      PlayerJump();
    }


    // ---------------------------------------------------------------------------------------------------------------------\

    // Movimento automatico do jogador pelo cenário.
    private void PlayerAutoMove()
    {
        if (GameStart)
        {
            
            this.transform.Translate(Vector3.forward * speedPlayer * Time.deltaTime);
        }
    }

    // Movimento horizontal do jogador através de 'Swipes' no touch.
    private void TouchMove()
    {
        if(dir.x > 0 && canMoveRight)
        {
            transform.Translate(dir * speedPlayer * 2f * Time.deltaTime, Camera.main.transform);
        }else if (dir.x < 0 && canMoveLeft)
        {
            transform.Translate(dir * speedPlayer * 2f * Time.deltaTime, Camera.main.transform);
        }
        
        
       

    }
    private void MoveD()
    {
        dir.x = playerJoystick.MovimentoHorizontal();
        //dir.y = playerJoystick.MovimentoVertical();
       
    }


    // Pulo do jogador através de uma força aplicada nos eixos X e Y ao Rigidbody do jogador. Fazendo o saltar para e cair em forma de arco.
    private void PlayerJump()
    {
        
        if(playerJoystick.Pulo() == true && canJump && playerJoystick.MovimentoVertical() >= 0.95f)
        {
            canJump = false;
            StartCoroutine(PlayerCanJump());
            this.playerRigidbody.AddForce(new Vector3(forceJump / 2, forceJump, 0) * forceJump);
            
        }
        
        


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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Direita"))
        {
            canMoveRight = false;
            canMoveLeft = true;
        }else if (collision.gameObject.CompareTag("Esquerda"))
        {
            canMoveRight = true;
            canMoveLeft = false;
        }else if(!collision.gameObject.CompareTag("Esquerda") && !collision.gameObject.CompareTag("Direita"))
        {
            canMoveRight = true;
            canMoveLeft = true;
        }
    }

    public void StartGame()
    {
        this.GameStart = true;
        playerAnimator.SetBool("Roll_Anim", true);
        musicBackground.Play();
        
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            uiManager.UpdateScore();
            Instantiate(explosion, this.transform.position,Quaternion.identity);
            Destroy(other.gameObject);
        }
    }

}

