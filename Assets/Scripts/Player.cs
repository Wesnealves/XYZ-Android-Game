using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speedPlayer = 1f; // Velocidade em que o player vai se mover.
    public bool isMovingZ = false; // Verifica se o jogador está se movendo no eixo Z. É uma variavel de controle.
    public float jumpForce = 50f; // Força do pulo definida com testes em gravidade do jogo em -10 ~ Na versão de Android aumentar para 100f ou até 250f.
    public Vector3 jumpDirectionX = new Vector3(0.2f,1,0); // Se o jogador estiver se movendo no eixo X, ele valor será passado para a direção do pulo. Para pular em arco.
    public Vector3 jumpDirectionZ = new Vector3(0, 1, 0.2f); // Se o jogador estiver se movendo no eixo Z, ele valor será passado para a direção do pulo. Para pular em arco.
    public LayerMask notIgnoreLayers = -1; // Nao ignora objetos que estiverem em todas as layers.
    public bool isGrounded, isJumping, canJump; // Está no chão, está pulando, pode pular.
    public bool callJump = false;
   
    private Rigidbody playerRigidbody;
    
    void Start()
    {
        this.playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PlayerJump();
    }
    void Update()
    {
        
        CheckGround();
        SwitchXZ();
        PlayerMove(); 
    }

    // Verifica se o jogador está se movendo no eixo X ou Z e troca o valor da variavel de controle.
    // Nota: Remover o Input de teclado para versão Android
    public void SwitchXZ()
    {
        if (Input.GetKey(KeyCode.Z) && isMovingZ == false)
        {
            isMovingZ = true;
        }
        else if (Input.GetKey(KeyCode.X) && isMovingZ == true)
        {
            isMovingZ = false;
        }
    }
    // Indica em qual eixo o jogador vai se mover.
    private void PlayerMove()
    {
        if(isMovingZ == false)
        {
            this.transform.Translate(1 * speedPlayer * Time.deltaTime, 0, 0);
        }
        else
        {
            this.transform.Translate(0, 0, 1 * speedPlayer * Time.deltaTime);
        }

        
    }
    // Verifica se o jogador está pulando, senão estiver, ele pula para a direção que ele estiver se movendo.
    public void PlayerJump()
    {
        // Emite um raio,que sai do jogador, para baixo em todas as Layers. Retorna verdadeiro ou falso.
        // isGrounded = Physics.Linecast(this.transform.position,transform.position - Vector3.up / 6,notIgnoreLayers);
        //Debug.DrawLine(this.transform.position, transform.position - Vector3.up /6);

        if (callJump == true || Input.GetKey(KeyCode.Space) && isGrounded == true && isMovingZ == false)
        {
            playerRigidbody.AddForce(jumpDirectionX * jumpForce * speedPlayer * Time.deltaTime, ForceMode.Impulse);
            callJump = false;
           
        }else if (callJump == true || Input.GetKey(KeyCode.Space)  && isGrounded == true && isMovingZ == true)
        {
            playerRigidbody.AddForce(jumpDirectionZ * jumpForce * Time.deltaTime, ForceMode.Impulse);
            callJump = false;
        }
        
    }
    // Emite um raio,que sai do jogador, para baixo em todas as Layers. Retorna verdadeiro ou falso.
    private void CheckGround()
    {
        isGrounded = Physics.Linecast(this.transform.position, transform.position - Vector3.up / 8, notIgnoreLayers);
        //Debug.Log(isGrounded);
    }

    // Intermedeia o click do botão com o metodo Jump.
    public void callJumping()
    {
        callJump = true;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ImpulseX"))
        {
            this.playerRigidbody.AddForce(new Vector3(5,0,0) * jumpForce * Time.deltaTime,ForceMode.Impulse);
        }
    }

}
