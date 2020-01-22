using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;



public class CustomClass : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerClickHandler
{
    
    public static HashSet<CustomClass> allCustomer = new HashSet<CustomClass>();
    

    public void OnSelect(BaseEventData eventData)
    {
        

    }

    public void OnDeselect(BaseEventData eventData)
    {


    }

    public void OnPointerClick(PointerEventData eventData)
    {



    }

}
