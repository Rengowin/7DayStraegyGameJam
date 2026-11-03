using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    BuildingData buildingData;
    [SerializeField]
    float timeLeftToProduceUnit;

    [SerializeField]
    FactionEnum Faction;
    [SerializeField]
    GameObject unitContainer;

    [SerializeField]
    Transform spawnPos;

    public BuildingData BuildingData => buildingData;

    public void Init(BuildingData buildingData, FactionEnum faction, GameObject unitContainer, Transform spawnPos)
    {
        this.buildingData = buildingData;
        this.Faction = faction;
        this.unitContainer = unitContainer;
        this.spawnPos = spawnPos;
    }


    void Update()
    {
        timeLeftToProduceUnit += Time.deltaTime;
        if (buildingData.ProductionTime < timeLeftToProduceUnit)
        {
            Produce();
            timeLeftToProduceUnit -= buildingData.ProductionTime;
        }
    }

    private void Produce()
    {
        switch(buildingData.GetBuildingType)
        {
            case BuildingEnum.Income:
                // Handle income production logic here
                break;
            case BuildingEnum.UnitProduction:
                SpawnUnit();
                break;
            case BuildingEnum.Buff:
                // Handle buff logic here
                break;
            default:
                Debug.LogWarning("Unknown building type");
                break;
        }
    }

    private void SpawnUnit()
    {
        Unit newUnit = Instantiate(
        buildingData.UnitPrefab,
        spawnPos.position,
        Quaternion.identity,
        unitContainer.transform
    );

        newUnit.Init(Faction);
    }
}
