using System;
using UnityEngine;

public class FrameInterpolator : MonoBehaviour
{
    public int targetFPS = 144; // The desired FPS
    private float targetFrameTime;
    private float lastFrameTime;

    void Start()
    {
        Application.targetFrameRate = -1; // Let Unity render at its fastest
        QualitySettings.vSyncCount = 0; // Disable v-sync
        targetFrameTime = 1f / targetFPS;
        lastFrameTime = Time.time;
    }

    void Update()
    {
        float timeSinceLastFrame = Time.time - lastFrameTime;

        if (timeSinceLastFrame >= targetFrameTime)
        {
            lastFrameTime = Time.time;
        }
        else
        {
            float interpolationFactor = timeSinceLastFrame / targetFrameTime;
            Interpolate(interpolationFactor);
        }
    }

    void Interpolate(float factor)
    {
        // 1. Get references to the objects you want to interpolate.
        // For example, if you want to interpolate the camera's position:
        // Camera camera = Camera.main;

        // 2. Store the previous frame's values.
        // For example:
        // Vector3 previousPosition = camera.transform.position;

        // 3. Calculate the interpolated values.
        // For example:
        // Vector3 interpolatedPosition = Vector3.Lerp(previousPosition, camera.transform.position, factor);

        // 4. Apply the interpolated values.
        // For example:
        // camera.transform.position = interpolatedPosition;

        // You can repeat steps 1-4 for other objects and values you want to interpolate.
    }
}
