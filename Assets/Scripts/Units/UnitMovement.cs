using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.AI;
public class UnitMovement : MonoBehaviour
{
    [SerializeField]
    UnitStats unitStats;
    bool moveToWayPoint = true;
    [SerializeField]
    float targetRange = 10f;
    [SerializeField]
    List<GameObject> waypoints = new List<GameObject>();

    [SerializeField]
    NavMeshAgent agent;

    //idk if needed but for test stuff its now :D
    int currentWaypointIndex = 0;


    void Update()
    {
        if (moveToWayPoint)
        {
            MoveToWayPoint();
        }
    }

    void MoveToWayPoint()
    {
        Debug.Log("Moving to waypoint");
        if (currentWaypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].transform.position;
            targetPosition.y = 0;
            agent.SetDestination(targetPosition);
        }
    }
}
