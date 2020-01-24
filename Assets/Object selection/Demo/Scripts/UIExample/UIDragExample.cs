using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragExample : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Text _Text;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.pointerCurrentRaycast.screenPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _Text.text = "You dragging!";
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _Text.text = "Drag me!";
    }
}
