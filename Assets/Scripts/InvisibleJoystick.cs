using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InvisibleJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler,IPointerUpHandler
{
    [SerializeField]
    Image bgImg, joyImg;
    public Vector3 inputDir;

    void Start()
    {
        bgImg = GetComponent<Image>();
        joyImg = transform.GetChild(0).GetComponent<Image>();
    }

  
    void Update()
    {

    }




    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform,eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputDir = new Vector3(pos.x * 2, pos.y * 2, 0);
            inputDir = (inputDir.magnitude > 1) ? inputDir.normalized : inputDir;
            joyImg.rectTransform.anchoredPosition = new Vector3(inputDir.x * bgImg.rectTransform.sizeDelta.x / 3,inputDir.y * bgImg.rectTransform.sizeDelta.y / 3);

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputDir = Vector3.zero;
        joyImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float MovimentoHorizontal()
    {
        if(inputDir.x != 0)
        {
            return inputDir.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float MovimentoVertical()
    {
        if (inputDir.y != 0)
        {
           
            return inputDir.y;
            
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }

    public bool Pulo()
    {
        if (inputDir.y != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
