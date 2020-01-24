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

    
    Color standart;

    
    void Awake() 
    {

        allSelectables.Add(this);

        objRenderer = GetComponent<Renderer>();
        standart = objRenderer.material.color;

    }

    void Start() 
    {
        //Messager.SendMassege("Всего выделяемых объектов: " + allSelectables.Count);

    }


    
    public void OnPointerClick(PointerEventData click)
    {
        //Messager.SendMassege("Произведено выделение объекта: " + click);
        if(!Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftControl))
        {
            DeselectAll(click);
        }
        OnSelect(click);
        


    }

    public void OnSelect(BaseEventData click)
    {            
        objRenderer.material.color = Color.green;
        //Messager.SendMassege("Select");
        
        hasBeenSelected.Add(this);
        isSelected = true;

    }

    
    public void OnDeselect(BaseEventData click)
    {
        objRenderer.material.color = standart;
        isSelected = false;
        //Messager.SendMassege("Deselect");

    }
    
    public static void DeselectAll(BaseEventData click)
    {

        foreach (Selectables selectables in hasBeenSelected)
        {
            //selectables.OnDeselect(click);
        }
        hasBeenSelected.Clear();


    }

}
