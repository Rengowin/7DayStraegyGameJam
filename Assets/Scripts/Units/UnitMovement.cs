using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.AI;
public class UnitMovement : MonoBehaviour
{
    AlllWayPoints allWayPoints;

    bool moveToWayPoint = true;

    [SerializeField]
    List<WayPoint> waypoints;

    Unit unit;
    NavMeshAgent agent;

    Rigidbody rb;
    SphereCollider sphereCollider;

    private void Awake()
    {
        unit = GetComponent<Unit>();
        agent = GetComponent<NavMeshAgent>();

        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void Start()
    {
        agent.speed = unit.UnitStats.Movement;

        sphereCollider.radius = unit.UnitStats.TargetRange;

        allWayPoints = AlllWayPoints.Instance;
        waypoints = allWayPoints.GetWayPoints();
    }

    void Update()
    {
        if (moveToWayPoint)
        {
            MoveToWayPoint();
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
        // insteat of moving to a waypoint, move to a target unit, unitl atkrange is met
    }

    private void OnTriggerEnter(Collider other)
    {
        Unit otherUnit = other.GetComponent<Unit>();
        if (otherUnit != null && unit.IsEnemy(otherUnit))
        {
            moveToWayPoint = false;
            if (agent.isActiveAndEnabled && agent.isOnNavMesh)
            {
                agent.isStopped = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Unit otherUnit = other.GetComponent<Unit>();
        if (otherUnit != null && unit.IsEnemy(otherUnit))
        {
            moveToWayPoint = true;
            if (agent.isActiveAndEnabled && agent.isOnNavMesh)
            {
                agent.isStopped = false;
            }
        }
    }
}