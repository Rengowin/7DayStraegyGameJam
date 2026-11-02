using UnityEngine;

public class UnitCombat : MonoBehaviour
{
    Unit unit;

    Rigidbody rb;
    SphereCollider sphereCollider;


    void Awake()
    {
        unit = GetComponent<Unit>();

        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Unit otherUnit = other.GetComponent<Unit>();
        if (otherUnit != null && unit.IsEnemy(otherUnit))
        {
            // Attack the enemy unit
            Attack(otherUnit);
        }
    }

    void Attack(Unit targetUnit)
    {
        targetUnit.TakeDamage(unit.UnitStats.Attack);
    }
}
