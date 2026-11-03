using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;


    InputSystem_Actions inputSystem;

    [SerializeField]
    CamControlls camControlls;

    [SerializeField]
    BuildingManager buildingManager;

    [SerializeField]
    Building testBuilding;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if(camControlls == null)
        {
            camControlls = CamControlls.Instance;
        }

        inputSystem = new InputSystem_Actions();
        inputSystem.Enable();

        inputSystem.BuildKeyBinds.SpawnTestBuilding.performed += ctx => buildingManager.SpawnBuilding(testBuilding.BuildingData, FactionEnum.Player);
        inputSystem.CamMovement.CamSpeedIncreseDecrease.performed += ctx => camControlls.ChangeCameraSpeed(ctx.ReadValue<float>());
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = inputSystem.CamMovement.CamMove.ReadValue<Vector2>();
        float zoomInput = inputSystem.CamMovement.Zoom.ReadValue<float>();

        camControlls.MoveCamera(movementInput);
        camControlls.ZoomCamera(zoomInput);
    }
}
