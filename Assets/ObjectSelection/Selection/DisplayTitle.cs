using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTitle : MonoBehaviour
{
    
    public Image title;
    public Camera screenCamera;
    /*
    private void Awake() 
    {
        title = GetComponent<Image>();
    }
    */
    private void Update() 
    {
        
        title.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        
        //Vector2 screnPosition = new Vector2();
        //Utility.WorldToScreenPoint(transform.position, out screnPosition);
        //title.transform.position = screnPosition;
    }
}
