using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Importe prieks interfeisiem
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IDragHandler,IEndDragHandler {
    //uzglaba noradi uz objektu skriptiem
    public Objekti objektuSkripts;
    //Velkamam objektam piestiprinata CanvasGroup komponente
    public CanvasGroup kanvasGrupa;
    //Objekta atrašanas vieta kurš tiek parvietots
    private RectTransform velkObjRectTransf;


    void Start()
    {
        //Piekļūjst objektam piestiprinātajai CanvasGroup
        kanvasGrupa= GetComponent<CanvasGroup>();
        //Piekļūst objekta RectTransform componentei
        velkObjRectTransf= GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Uzklikšķināts uz velkama objekta!");   
    }

    public void OnDrag(PointerEventData eventData)
    {
     
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      

    }
}
