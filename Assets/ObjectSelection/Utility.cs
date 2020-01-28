using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static Vector3 WorldToScreenPoint(Vector3 worldPosition)
    {       
        return Camera.main.WorldToScreenPoint(worldPosition);
    }


}
