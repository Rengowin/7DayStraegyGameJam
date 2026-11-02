using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitStats", menuName = "Scriptable Objects/UnitStats")]
public class UnitStats : ScriptableObject
{
    [Header("Unit Type")]
    [SerializeField]
    UnitType unitType;
    [Header("Target Priority")]
    [SerializeField]
    TargetPriority targetPriority;

    [Header("Combat Stats")]
    [SerializeField]
    float health;
    [SerializeField]
    float attack;

    [Header("Range Stats")]
    [SerializeField]
    float attackRange;
    [SerializeField]
    float targetRange;
    [SerializeField]
    float aoeRange = 0f;

    [Header("Movement")]
    [SerializeField]
    float movement;

    public UnitType UnitType => unitType;
    public float Health => health;
    public float Attack => attack;
    public float AttackRange => attackRange;
    public float TargetRange => targetRange;
    public float AoeRange => aoeRange;
    public float Movement => movement;
}
