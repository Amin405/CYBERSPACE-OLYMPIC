using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector2 offset;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (target != null)
        {
            CalculateOffset();
        }
    }

    void CalculateOffset()
    {
        float cameraHeight = 2f * cam.orthographicSize;
        float cameraWidth = cameraHeight * cam.aspect;
        Vector3 targetPosition = target.transform.position;
        offset.x = cameraWidth / 2 - targetPosition.x + transform.position.x;
        offset.y = 0; // Set y offset to 0 to keep the height constant
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate the new position for the camera
            float cameraHeight = 2f * cam.orthographicSize;
            float cameraWidth = cameraHeight * cam.aspect;
            Vector3 targetPosition = target.transform.position;
            float x = targetPosition.x - cameraWidth / 2 + offset.x;
            float y = transform.position.y;
            float z = transform.position.z;

            // Set the camera's new position
            transform.position = new Vector3(x, y, z);
        }
    }

    public void SetNewTarget(GameObject newTarget)
    {
        target = newTarget;
        CalculateOffset();
    }
}