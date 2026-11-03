using UnityEngine;

public class CamControlls : MonoBehaviour
{
    public static CamControlls Instance;

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float rotationSpeed = 100f;

    [SerializeField, Range(5, 300)]
    float zoomRange = 100;
    [SerializeField]
    float zoomSpeed = 5f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MoveCamera(Vector2 movementInput)
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    public void ZoomCamera(float zoomInput)
    {
        float zoomAmount = zoomInput * zoomSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + transform.forward * zoomAmount;
        newPosition.y = Mathf.Clamp(newPosition.y, 5f, zoomRange);
        transform.position = newPosition;
    }

    public void ChangeCameraSpeed(float speedChange)
    {
        speed += speedChange;
        speed = Mathf.Clamp(speed, 1f, 100f);
    }
}
