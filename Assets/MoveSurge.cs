using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveSurge : MonoBehaviour
{
    public GameObject[] points; // List of transforms to follow
    public float journeyTime = 10f; // Total time for the journey in seconds

    private List<Vector3> waypoints; // List of Vector3 positions derived from the Transforms
    private float totalDistance; // Total distance of the path
    private float elapsedTime; // Time elapsed since the start of the journey
    private int currentPointIndex; // Index of the current point in waypoints

    private void Start()
    {
        //points = GameObject.FindGameObjectsWithTag("SurgePoint");


        // Initialize variables
        waypoints = new List<Vector3>();
        totalDistance = 0f;
        elapsedTime = 0f;
        currentPointIndex = 0;

        // Convert Transforms to Vector3s and calculate total distance
        if (points != null && points.Length > 1)
        {
            for (int i = 0; i < points.Length; i++)
            {
                waypoints.Add(points[i].transform.position);
                if (i > 0)
                {
                    totalDistance += Vector3.Distance(waypoints[i - 1], waypoints[i]);
                }
            }
        }
        else
        {
            Debug.LogError("Please assign at least two points to the points list.");
        }
    }

    private void Update()
    {
        if (waypoints == null || waypoints.Count < 2 || totalDistance <= 0)
            return;

        // Calculate the normalized time (0 to 1) over the journey
        elapsedTime += Time.deltaTime;
        float normalizedTime = elapsedTime / journeyTime;

        if (normalizedTime > 1f)
        {
            // Ensure the GameObject stops at the final point
            transform.position = waypoints[waypoints.Count - 1];
            enabled = false; // Stop updating
            return;
        }

        // Calculate the current distance the object should travel
        float currentDistance = normalizedTime * totalDistance;

        // Find the segment the object is currently in
        float traveledDistance = 0f;
        for (int i = 1; i < waypoints.Count; i++)
        {
            float segmentDistance = Vector3.Distance(waypoints[i - 1], waypoints[i]);
            if (traveledDistance + segmentDistance >= currentDistance)
            {
                // Interpolate along the current segment
                float segmentNormalized = (currentDistance - traveledDistance) / segmentDistance;
                transform.position = Vector3.Lerp(waypoints[i - 1], waypoints[i], segmentNormalized);
                break;
            }
            traveledDistance += segmentDistance;
        }
    }
}
