using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool canStart = false;
    [SerializeField]
    Animator playerAnimator;
    [SerializeField]
    PlayerAndroid player;
    Touch touch;

    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        player = GetComponent<PlayerAndroid>();
    }
   

    void Update()
    {
        if(Input.touchCount > 0 && !canStart)
        {
            canStart = true;
            StartCoroutine("StartGame");
        }
    }

    public IEnumerator StartGame()
    {
        playerAnimator.SetBool("Idle_to_start", true);
        yield return new WaitForSeconds(0.7f);
        player.StartGame();
    }
}
