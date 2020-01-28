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
        
        
        
        
        //Vector3 titlePos = camera.WorldToScreenPoint(this.transform.position);
        //Vector3 titlePos = new Vector3(transform.position.x, transform.position.y);
        //Vector3 titlePos = Camera.main.WorldToScreenPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.nearClipPlane));
        //title.transform.position = Camera.main.WorldToScreenPoint(titlePos);
        
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
