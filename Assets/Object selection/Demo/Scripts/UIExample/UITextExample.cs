using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UITextExample : MonoBehaviour, IPointerClickHandler
{
	private Text _Text;
	private bool _IsClicked;
	private void Start ()
	{
		_Text = GetComponent<Text>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		_Text.text = _IsClicked ? "Hello there!" : "General Kenobi";
		_IsClicked = !_IsClicked;
	}
}
