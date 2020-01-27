using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionDragAndDropHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image _SelectionBoxSprite;
    
    private Rect rect;
    Vector3 startPosition;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftControl))
        {
            SelectableObject.DeselectAllSelectedObjects();
        }
        
        startPosition = eventData.position;
        rect = new Rect();

    }


    public void OnDrag(PointerEventData eventData)
    {
        _SelectionBoxSprite.gameObject.SetActive(true);
        if (eventData.position.x < startPosition.x)
        {
            rect.xMin = eventData.position.x;
            rect.xMax = startPosition.x;
        }
        else
        {
            rect.xMin = startPosition.x;
            rect.xMax = eventData.position.x;
            
        }

        if (eventData.position.y < startPosition.y)
        {
            rect.yMin = eventData.position.y;
            rect.yMax = startPosition.y;
        }
        else
        {
            rect.yMin = startPosition.y;
            rect.yMax = eventData.position.y;
            
        }
        
        _SelectionBoxSprite.rectTransform.offsetMin = rect.min;
        _SelectionBoxSprite.rectTransform.offsetMax = rect.max;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _SelectionBoxSprite.gameObject.SetActive(false);

        foreach (SelectableObject sObj in SelectableObject.AllSelectableObjects)
        {
            if(rect.Contains(Camera.main.WorldToScreenPoint(sObj.transform.position)))
            {
                
                sObj.SelectObject();
                Debug.Log("Всего выделенных объектов: " + SelectableObject.AllSelectedObjectCount());
                
            }
        }
    }
}