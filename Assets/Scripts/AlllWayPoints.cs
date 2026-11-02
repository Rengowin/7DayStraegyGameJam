using UnityEngine;
using System.Collections.Generic;

public class AlllWayPoints : MonoBehaviour
{
    public static AlllWayPoints Instance { get; private set; }

    [SerializeField]
    List<WayPoint> waypoints = new List<WayPoint>();

    public List<WayPoint> GetWayPoints()
    {
        return waypoints;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
