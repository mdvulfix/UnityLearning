using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSelectionHandler : MonoBehaviour, IDragHandler ,IBeginDragHandler//, IEndDragHandler
{

    Vector2 selectorStartPoint;
    Rect rect;
    Image image;
    
    
    public void OnBeginDrag(PointerEventData eventData)
    {

        image = GetComponent<Image>();
        image.gameObject.SetActive(true);

        selectorStartPoint = eventData.position;
        rect = new Rect();
        

    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.position.x < selectorStartPoint.x)
        {
            rect.xMin = eventData.position.x;
            rect.xMax = selectorStartPoint.x;
        }
        else
        {
            rect.xMin = selectorStartPoint.x;
            rect.xMax = eventData.position.x;
            
        }

        if (eventData.position.y < selectorStartPoint.y)
        {
            rect.yMin = eventData.position.y;
            rect.yMax = selectorStartPoint.y;
        }
        else
        {
            rect.yMin = selectorStartPoint.y;
            rect.yMax = eventData.position.y;
            
        }

        image.rectTransform.offsetMin = rect.min;
        image.rectTransform.offsetMax = rect.max;

    }

 
    /*
    public void OnEndDrag(PointerEventData eventData)
    {

        selectables.DeselectAll(eventData);

    }

    public static void DeselectAll(BaseEventData eventData)
    {

        foreach (Selectables selectables in hasBeenSelected)
        {
            selectables.OnDeselect(eventData);
        }
        hasBeenSelected.Clear();


    }
    */



}
