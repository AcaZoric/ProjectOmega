using UnityEngine;
using System.Collections;

public class CameraMovementScript : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 newCameraPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, smoothing * Time.deltaTime);
    }
}
