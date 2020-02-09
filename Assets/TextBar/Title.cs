using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    
    public Text title;
    public Image box;
    //public Camera camera;
    //Rect rect;
    Renderer objRenderer;
    Bounds objBounds;
    Vector3 pos, posbox;
    public Vector2 min, max;

    public RectTransform UI_Element;
    public Canvas can;
    
    private void Awake()
    {

        //UpdateRect();
        objRenderer = GetComponent<Renderer>();
        objBounds = objRenderer.bounds;
        //Messager.SendMassege(Camera.main.WorldToViewportPoint(this.transform.position).ToString());
        pos = Camera.main.WorldToScreenPoint(objBounds.center);
        //Messager.SendMassege(pos.ToString());
        title.transform.position = pos;
            
    }
    
    private void Update() 
    {
        
        objBounds = objRenderer.bounds;
        pos = Camera.main.WorldToScreenPoint(objBounds.center);
        posbox = Camera.main.WorldToScreenPoint(objBounds.center);

        pos.y = pos.y - Screen.height/2 + 100f;
        pos.x = pos.x - Screen.width/2;
        title.transform.localPosition = pos;
        
        posbox.y = posbox.y - Screen.height/2;
        posbox.x = posbox.x - Screen.width/2;
        
        box.transform.localPosition = posbox;
        
        //box.rectTransform.offsetMin = min;
        //box.rectTransform.offsetMax = max;
        
        GetInfo();
        
        
        //Vector3 titlePos = camera.WorldToScreenPoint(this.transform.position);
        //Vector3 titlePos = new Vector3(transform.position.x, transform.position.y);
        //Vector3 titlePos = Camera.main.WorldToScreenPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.nearClipPlane));
        //title.transform.position = Camera.main.WorldToScreenPoint(titlePos);
        
        //Vector2 screnPosition = new Vector2();
        //Utility.WorldToScreenPoint(transform.position, out screnPosition);
        //title.transform.position = screnPosition;

        //this is your object that you want to have the UI element hovering over
    
        //this is the ui element
        

    
    
 
        /*
        //first you need the RectTransform component of your canvas
        RectTransform CanvasRect = can.GetComponent<RectTransform>();

        //then you calculate the position of the UI element
        //0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5f to get the correct position.

        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * CanvasRect.sizeDelta.x)-(CanvasRect.sizeDelta.x * 0.5f)),
           ((ViewportPosition.y * CanvasRect.sizeDelta.y)-(CanvasRect.sizeDelta.y * 0.5f)));

        //now you can set the position of the ui element
        
        //Vector2 WorldObject_ScreenPosition = new Vector2(ViewportPosition.x * CanvasRect.sizeDelta.x,ViewportPosition.y * CanvasRect.sizeDelta.y); 
        
        
        
        
        UI_Element.anchoredPosition = WorldObject_ScreenPosition;
        */





    }

    private void GetInfo()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Messager.SendMassege(Camera.main.WorldToViewportPoint(objBounds.center).ToString());
            Messager.SendMassege(Camera.main.WorldToViewportPoint(objBounds.center + objBounds.extents).ToString());
            Messager.SendMassege(Camera.main.WorldToViewportPoint(objBounds.center - objBounds.extents).ToString());
            //Messager.SendMassege(Camera.main.WorldToViewportPoint(objBounds.center + objBounds.extents).ToString());
            //Messager.SendMassege(Camera.main.WorldToScreenPoint(objBounds.center + objBounds.extents).ToString());

        }
    }

}

