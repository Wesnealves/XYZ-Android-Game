using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class pressButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public float input,sensitility = 3f;
    public bool pressing;
   
    

   
    void Update()
    {
        if (pressing)
        {
            input += Time.deltaTime * sensitility;
        }
        else
        {
            input -= Time.deltaTime * sensitility;
        }
        input = Mathf.Clamp(input, 0, 1);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;
    }
}
