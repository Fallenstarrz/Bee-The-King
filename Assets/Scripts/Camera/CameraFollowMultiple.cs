using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollowMultiple : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;
    public float smoothRate;
    public float minZoom = 40;
    public float maxZoom = 10;
    public float zoomLimiter;

    private Vector3 velocity;
    private Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }
        cameraMovement();
        cameraZoom();
    }

    private void cameraZoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, getGreatestDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
    }

    float getGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    private void cameraMovement()
    {
        Vector3 centerPoint = getCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothRate);
    }

    Vector3 getCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
