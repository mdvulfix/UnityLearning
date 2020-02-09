using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class Program : MonoBehaviour
    {

        void Start()
        {

            Scout scout = new Scout();
            scout.Move();

        }
    }
}
