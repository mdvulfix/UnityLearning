using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhysicsExample : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
	[SerializeField] private MeshRenderer _Renderer;
	private Material _Material;
	
	void Start ()
	{
		_Material = _Renderer.material;
	}


	public void OnPointerEnter(PointerEventData eventData)
	{
		_Material.color = Color.blue;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_Material.color = Color.white;
		
	}
	public void OnDrag(PointerEventData eventData)
	{
		var hitPos = eventData.pointerCurrentRaycast.worldPosition;
		transform.position = new Vector3(hitPos.x, hitPos.y, 1);
	}

	
}
