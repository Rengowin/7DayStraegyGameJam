using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    UnitStats unitStats;

    float currentHealth;

    [SerializeField]
    FactionEnum factionEnum;

    [SerializeField]
    Transform currentTarget;

    UnitMovement unitMovement;

    public UnitStats UnitStats => unitStats;
    public FactionEnum FactionEnum => factionEnum;

    public Transform Target {
        get => currentTarget; 
        set => currentTarget = value;
    }

    public void Init(FactionEnum faction)
    {
        factionEnum = faction;
    }

    private void Awake()
    {
        currentHealth = unitStats.Health;
        unitMovement = GetComponent<UnitMovement>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public bool IsEnemy(Unit otherUnit)
    {
        return factionEnum != otherUnit.FactionEnum;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void LookForTarget()
    {
        if (currentTarget == null)
        {
            // Logic to find a new target
            Collider[] hits = Physics.OverlapSphere(transform.position, unitStats.TargetRange);
            foreach (var hit in hits)
            {
                Unit potentialTarget = hit.GetComponent<Unit>();
                if (potentialTarget != null && IsEnemy(potentialTarget))
                {
                    currentTarget = potentialTarget.transform;
                    unitMovement.IsFollowingWaypoints = false;
                    break;
                }    
            }
            if(currentTarget == null)
            {
                unitMovement.IsFollowingWaypoints = true;
            }
        }
        else
        {
            // maybe a refreah timer to check unknow yet since little time :3
        }
    }
}
