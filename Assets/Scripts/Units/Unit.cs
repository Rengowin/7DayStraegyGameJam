using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    UnitStats unitStats;

    float currentHealth;

    [SerializeField]
    FactionEnum factionEnum;

    public UnitStats UnitStats => unitStats;
    public FactionEnum FactionEnum => factionEnum;

    private void Awake()
    {
        currentHealth = unitStats.Health;
    }

    public void Init(Faction faction)
    {
        factionEnum = faction.GetFactionEnum();
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
}
