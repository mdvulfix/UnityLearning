using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class SelectableObject : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerClickHandler
{
    [SerializeField] private bool isSelected;

    Color standartColor;
    Renderer objRenderer;


    public static HashSet<SelectableObject> AllSelectableObjects = new HashSet<SelectableObject>();
    public static HashSet<SelectableObject> AllSelectedObject = new HashSet<SelectableObject>();
    
    
    private void Awake() 
    {
        
        isSelected = false;
        AllSelectableObjects.Add(this);
        objRenderer = GetComponent<Renderer>();
        standartColor = objRenderer.material.color;

    }

    public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log(eventData);
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData click)
    {            
        objRenderer.material.color = Color.green;
        //Messager.SendMassege("Select");
        
        //hasBeenSelected.Add(this);
        //isSelected = true;

    }

    public void OnDeselect(BaseEventData click)
    {
        objRenderer.material.color = standartColor;
        //isSelected = false;
        //Messager.SendMassege("Deselect");

    }





    public void SelectObject()
    {
        if(isSelected == false) 
        {
            AllSelectedObject.Add(this);
            transform.GetComponent<Renderer>().material.color = Color.green;
            isSelected = true;
        }
    }

    public void DeselectObject()
    {
        isSelected = false;
        transform.GetComponent<Renderer>().material.color = standartColor;
        //AllSelectedObject.Remove(this);

    }

    public static void DeselectAllSelectedObjects()
    {
        foreach (SelectableObject sObj in AllSelectedObject)
        {
            sObj.DeselectObject();
        }
        AllSelectedObject.Clear();
                
    }

    public static int AllSelectedObjectCount()
    {
        return AllSelectedObject.Count;
                
    }


}
