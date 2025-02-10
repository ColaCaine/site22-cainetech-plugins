using System;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityOptimizer : MonoBehaviour
{
    public float cullDistance = 100f; // Distance beyond which objects are culled
    public LayerMask targetLayers; // Layers to consider for culling

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Get all objects on the target layers within the scene
        GameObject[] objects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in objects)
        {
            if (((1 << obj.layer) & targetLayers) != 0) // Check if object is on a target layer
            {
                // Calculate distance from camera to object
                float distance = Vector3.Distance(mainCamera.transform.position, obj.transform.position);

                if (distance > cullDistance)
                {
                    // Cull object if beyond cull distance
                    obj.SetActive(false);
                }
                else
                {
                    // Check if object is in camera's view
                    Vector3 viewportPos = mainCamera.WorldToViewportPoint(obj.transform.position);

                    if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1 || viewportPos.z < 0)
                    {
                        // Cull object if outside camera's view
                        obj.SetActive(false);
                    }
                    else
                    {
                        // Enable object if within camera's view and within cull distance
                        obj.SetActive(true);
                    }
                }
            }
        }
    }
}
