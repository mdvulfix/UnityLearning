using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    
    public Text title;
    public Image box;
    //Rect rect;

    
    private void Awake()
    {
        //UpdateRect();
    }
    
    private void Update() 
    {
        Vector3 titlePos = Camera.main.WorldToScreenPoint(this.transform.position);
        //Vector3 titlePos = Camera.main.WorldToScreenPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.nearClipPlane));
        title.transform.position = titlePos*0.01f;
        
        //Vector2 screnPosition = new Vector2();
        //Utility.WorldToScreenPoint(transform.position, out screnPosition);
        //title.transform.position = screnPosition;
    }

    private void UpdateRect()
    {

        box.rectTransform.offsetMin = GetComponent<Renderer>().bounds.min;
        box.rectTransform.offsetMax = GetComponent<Renderer>().bounds.max;

    }

}
