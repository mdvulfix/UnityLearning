using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



[System.Serializable]
public class Selectables : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerClickHandler
{
    
    public static HashSet<Selectables> allSelectables = new HashSet<Selectables>();
    public static HashSet<Selectables> hasBeenSelected = new HashSet<Selectables>();
    
    Renderer objRenderer;
    
    [SerializeField]
    bool isSelected = false;

    [SerializeField]
    Material greenMat;

     [SerializeField]
    Material blueMat;
    
    //Color standart;

    
    void Awake() 
    {

        allSelectables.Add(this);

        objRenderer = GetComponent<Renderer>();
        //standart = objRenderer.material.color;

    }

    void Start() 
    {
        //Messager.SendMassege("Всего выделяемых объектов: " + allSelectables.Count);

    }


    
    public void OnPointerClick(PointerEventData eventData)
    {
        //Messager.SendMassege("Произведено выделение объекта: " + click);
        OnSelect(eventData);
        


    }

    public void OnSelect(BaseEventData eventData)
    {
        
        DeselectAll(eventData);
        objRenderer.material = greenMat;
        Messager.SendMassege("Select");
        
        hasBeenSelected.Add(this);
        isSelected = true;


    }

    public void OnDeselect(BaseEventData eventData)
    {
        objRenderer.material = blueMat;
        isSelected = false;
        Messager.SendMassege("Deselect");

    }

    public static void DeselectAll(BaseEventData eventData)
    {

        foreach (Selectables selectables in hasBeenSelected)
        {
            selectables.OnDeselect(eventData);
        }
        hasBeenSelected.Clear();


    }

}
