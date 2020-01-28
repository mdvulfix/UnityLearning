using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;




[System.Serializable]
public class SelectionClickHandler : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerClickHandler
{
    public GameObject selectObject;
    Vector2 mouseClickPosition;

    public void OnPointerClick(PointerEventData eventData)
    {
        
        mouseClickPosition = eventData.position;
        Messager.SendMassege("Клик по объекту: " + eventData);
        if(!Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftControl))
        {
            //DeselectAll(eventData);
        }
                
        //OnSelect(eventData);
        //mouseClickPosition = eventData.position;
        Vector2 objOnScreen = new Vector2();
        //Utility.WorldToScreenPoint(selectObject.transform.position, out objOnScreen);
        
        Debug.Log("Позиция объекта: " + objOnScreen);
        foreach (SelectableObject sObj in SelectableObject.AllSelectableObjects)
        {

            if(mouseClickPosition == objOnScreen)
            {
                sObj.SelectObject();
                Debug.Log("Всего выделенных объектов: " + SelectableObject.AllSelectedObjectCount());
                
            }
        }
        
        
        
        
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData eventData)
    {            
        //Messager.SendMassege("Выделение объекта: " + eventData.selectedObject.transform.position);


    } 


    
    public void OnDeselect(BaseEventData eventData)
    {


    }
}