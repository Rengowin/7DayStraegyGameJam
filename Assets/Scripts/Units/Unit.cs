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

    public void Init(FactionEnum faction)
    {
        factionEnum = faction;
    }

    private void Awake()
    {
        currentHealth = unitStats.Health;
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
