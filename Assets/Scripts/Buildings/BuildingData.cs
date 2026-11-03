using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Scriptable Objects/BuildingData")]
public class BuildingData : ScriptableObject
{
    [Header("Not Building related")]
    [SerializeField]
    Sprite buildingSprite; //idk if i have time for that
    [SerializeField]
    Unit unitPrefab;

    [SerializeField]
    GameObject buildingPrefab;

    [Header("Building Stats")]
    [SerializeField]
    int buildGoldCost;
    [SerializeField]
    float productionTime;

    [SerializeField]
    BuildingEnum BuildingType; // maybe if i have time for building specific buffs

    public Sprite BuildingSprite => buildingSprite;
    public Unit UnitPrefab => unitPrefab;

    public GameObject BuildingPrefab => buildingPrefab;
    public int BuildGoldCost => buildGoldCost;
    public float ProductionTime => productionTime;
    public BuildingEnum GetBuildingType => BuildingType;

}
