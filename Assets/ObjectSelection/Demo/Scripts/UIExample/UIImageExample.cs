using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIImageExample : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	private Image _Image;

	private void Awake()
	{
		_Image = GetComponent<Image>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_Image.color = Color.blue;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_Image.color = Color.white;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_Image.color = Color.green;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_Image.color = Color.red;
	}

}
