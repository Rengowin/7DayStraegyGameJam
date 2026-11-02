using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitStats", menuName = "Scriptable Objects/UnitStats")]
public class UnitStats : ScriptableObject
{
    [Header("Unit Type")]
    [SerializeField]
    UnitComboTyps unitComboTyp;

    [Header("Combat Stats")]
    [SerializeField]
    float health;
    [SerializeField]
    float attack;
    [SerializeField]
    float defense;

    [Header("Attack Range")]
    [SerializeField]
    float attackRange;

    [Header("Movement")]
    [SerializeField]
    float movement;

    public UnitComboTyps UnitComboTyp => unitComboTyp;
    public float Health => health;
    public float Attack { get => attack; set => attack = value; }
    public float Defense { get => defense; set => defense = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public float Movement { get => movement; set => movement = value; }


}
