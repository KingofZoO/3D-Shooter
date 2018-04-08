using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsController : MyBaseController
{
    private List<Vector3> wayPoints = new List<Vector3>();

    private void Start()
    {
        var findedWayPoints = GameObject.FindGameObjectsWithTag("Way Point");
        foreach (var point in findedWayPoints)
            wayPoints.Add(point.transform.position);
    }

    public Vector3 GetRandomWayPoint()
    {
        return wayPoints[Random.Range(0, wayPoints.Count)];
    }
}
