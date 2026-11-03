using UnityEngine;

public class UnitCombat : MonoBehaviour
{
    Unit unit;

    void Awake()
    {
        unit = GetComponent<Unit>();
    }

    void Update()
    {
        
    }

    void Attack(Unit targetUnit)
    {
        targetUnit.TakeDamage(unit.UnitStats.Attack);
    }
}
