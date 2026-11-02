using UnityEngine;

public class CamControlls : MonoBehaviour
{
    public static CamControlls Instance { get; private set; }

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float rotationSpeed = 100f;

    [SerializeField, Range(5, 100)]
    float zoomRange = 20;
    [SerializeField]
    float zoomSpeed = 10f;

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
}
