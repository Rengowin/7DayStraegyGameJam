using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.AI;
public class UnitMovement : MonoBehaviour
{
    AlllWayPoints allWayPoints;

    bool isFollowingWaypoints = true;

    [SerializeField]
    List<WayPoint> waypoints;

    Unit unit;
    NavMeshAgent agent;

    public bool IsFollowingWaypoints
    {
        get => isFollowingWaypoints;
        set => isFollowingWaypoints = value;
    }

    private void Awake()
    {
        unit = GetComponent<Unit>();
        agent = GetComponent<NavMeshAgent>();

    }

    private void Start()
    {
        agent.speed = unit.UnitStats.Movement;

        allWayPoints = AlllWayPoints.Instance;
        waypoints = allWayPoints.GetWayPoints();
    }

    void Update()
    {
        if (IsFollowingWaypoints)
        {
            MoveToWayPoint();
        }
        else
        {
            MoveToTarget();
        }
    }

    void MoveToWayPoint()
    {
        foreach (WayPoint wayPoint in waypoints)
        {
            if (wayPoint.Faction != unit.FactionEnum)
            {
                Vector3 targetPosition = wayPoint.transform.position;
                targetPosition.y = 0;
                agent.SetDestination(targetPosition);
            }
        }
    }

    void MoveToTarget()
    {
        if (unit.Target != null)
        {
            Vector3 targetPosition = unit.Target.position;
            targetPosition.y = 0;
            agent.SetDestination(targetPosition);
        }
    }
}