using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField]
    FactionEnum factionEnum;

    public FactionEnum Faction => factionEnum;
    public Vector3 Postion => transform.position;
}
