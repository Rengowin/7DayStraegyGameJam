using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance;

    [SerializeField]
    GameObject playerBuildingContainer;
    [SerializeField]
    GameObject enemyBuildingContainer;

    [SerializeField]
    GameObject playerUnitContainer;
    [SerializeField]
    GameObject enemyUnitContainer;


    //fornow the HQ's maybe later the buildings will spawn where the stay
    [SerializeField]
    Transform playerSpawnPos;
    [SerializeField]
    Transform enemySpawnPos;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnBuilding(BuildingData buildingData, FactionEnum faction)
    {
        if(faction == FactionEnum.Player)
        {
            Building newBuilding = Instantiate(
                buildingData.BuildingPrefab,
                playerSpawnPos.position,
                Quaternion.identity,
                playerBuildingContainer.transform
            ).GetComponent<Building>();
            newBuilding.Init(buildingData, faction, playerUnitContainer, playerSpawnPos);
        }
        else
        {
            Building newBuilding = Instantiate(
                buildingData.BuildingPrefab,
                enemySpawnPos.position,
                Quaternion.identity,
                enemyBuildingContainer.transform
            ).GetComponent<Building>();
            newBuilding.Init(buildingData, faction, enemyUnitContainer, enemySpawnPos);
        }
    }
}
