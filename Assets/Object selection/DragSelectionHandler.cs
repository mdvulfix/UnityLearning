using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSelectionHandler : MonoBehaviour, IDragHandler ,IBeginDragHandler, IEndDragHandler
{
    
    [SerializeField]
    Image _DragSelectionBox;
    
    Rect rect;
    Vector2 selectorStartPoint;
    
    void Awake() {
        _DragSelectionBox.gameObject.SetActive(false);

    }


    public void OnBeginDrag(PointerEventData eventData)
    {

        Debug.Log("Start dragging");
        if(!Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftControl))
        {
            Selectables.DeselectAll(new BaseEventData(EventSystem.current));
        }
        
        _DragSelectionBox.gameObject.SetActive(true);
        selectorStartPoint = eventData.position;
        rect = new Rect();
        

    }
    
    public void OnDrag(PointerEventData eventData)
    {
        
      
        
        Debug.Log("Continue dragging");
        
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

        _DragSelectionBox.GetComponent<Image>().rectTransform.offsetMin = rect.min;
        _DragSelectionBox.GetComponent<Image>().rectTransform.offsetMax = rect.max;

    }

 
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Stop dragging");
        _DragSelectionBox.gameObject.SetActive(false);
        foreach (Selectables selectables in Selectables.allSelectables)
        {
            if(rect.Contains(Camera.main.WorldToScreenPoint(selectables.transform.position)))
            selectables.OnSelect(eventData);
        }
    }

}
