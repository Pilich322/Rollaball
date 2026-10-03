using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float smoothSpeed = 0.5f;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        if (!player.IsDestroyed())
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref velocity, smoothSpeed);
    }
}