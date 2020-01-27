using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static void WorldToScreenPoint(Vector3 worldPosition, out Vector2 screenPosition)
    {

        Vector2 position = new Vector2()
        {            
            x = Camera.main.WorldToScreenPoint(worldPosition).x,
            y = Camera.main.WorldToScreenPoint(worldPosition).y
        };
        
        screenPosition = position;
    }

    public static void WorldToScreenPoint(Vector3 worldPosition, out Vector3 screenPosition)
    {       
        screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
    }


}
