using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    void Start()
    {
        PrintWaypointName();
    }

    void PrintWaypointName()
    {
        foreach(Waypoint waypoint in path)
        {
            Debug.Log(waypoint.name);
        }
    }
}
