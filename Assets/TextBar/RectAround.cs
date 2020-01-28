using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectAround : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float margin = 0;
    public Image imageBox;
    
    private Vector3[] pts = new Vector3[8];
    Bounds b;
    Camera cam;
    Rect r;
    Rect rect;
 
    
    private void Awake()
    {
        b = player.GetComponent<Renderer>().bounds;
        cam = Camera.main;
        r = new Rect();
        rect = new Rect();
        
    }
    
    
    
    private void Start() 
    {

    
    }
    
    private void Update()
    {
        DrawRect(b);

    }

    
    Vector2 top;
    Vector2 bottom;

    public void DrawRect(Bounds b) 
    {
             
        top = new Vector2(b.center.x +  b.extents.x , b.center.y +  b.extents.y);
        bottom = new Vector2(b.center.x - b.extents.x , b.center.y - b.extents.y);
        
        rect.xMax = top.x;
        rect.xMin = bottom.x;
        rect.yMax = top.y;
        rect.yMin = bottom.y;

        imageBox.rectTransform.offsetMin = rect.min * 100f;
        imageBox.rectTransform.offsetMax = rect.max* 100f ;
        
        
        /*
        //The object is behind us
        if (cam.WorldToScreenPoint (b.center).z < 0) return;
     
        //All 8 vertices of the bounds
        pts[0] = cam.WorldToScreenPoint (new Vector3 (b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z));
        pts[1] = cam.WorldToScreenPoint (new Vector3 (b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z));
        pts[2] = cam.WorldToScreenPoint (new Vector3 (b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z));
        pts[3] = cam.WorldToScreenPoint (new Vector3 (b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z));
        pts[4] = cam.WorldToScreenPoint (new Vector3 (b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z));
        pts[5] = cam.WorldToScreenPoint (new Vector3 (b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z));
        pts[6] = cam.WorldToScreenPoint (new Vector3 (b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z));
        pts[7] = cam.WorldToScreenPoint (new Vector3 (b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z));
     
        //Get them in GUI space
        for (int i=0;i<pts.Length;i++) pts[i].y = Screen.height-pts[i].y;
        
        //Calculate the min and max positions
        Vector3 min = pts[0];
        Vector3 max = pts[0];
        for (int i=1;i<pts.Length;i++) {
            min = Vector3.Min (min, pts[i]);
            max = Vector3.Max (max, pts[i]);
        }
     
        //Construct a rect of the min and max positions and apply some margin
        r = Rect.MinMaxRect (min.x,min.y,max.x,max.y);
        r.xMin -= margin;
        r.xMax += margin;
        r.yMin -= margin;
        r.yMax += margin;
        
        //Render the box
        //GUI.Box (r,"This is a box covering the player");
        imageBox.rectTransform.offsetMin = r.min;
        imageBox.rectTransform.offsetMax = r.max;

        */
    }
}
