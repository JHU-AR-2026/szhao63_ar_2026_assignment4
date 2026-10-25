using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        // Save the camera's initial offset from the player
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        // Keep the same offset while following the player
        transform.position = player.transform.position + offset;
    }
}