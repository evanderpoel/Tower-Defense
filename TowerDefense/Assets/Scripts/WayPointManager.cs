using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public static Transform[] WayPoints;

    private void Awake()
    {
        WayPoints = new Transform[transform.childCount];
        for (int i = 0; i < WayPoints.Length; i++)
        {
            WayPoints[i] = transform.GetChild(i);
        }
    }
}
