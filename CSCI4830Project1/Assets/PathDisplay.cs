using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class PathDisplay : MonoBehaviour
{
    public PlayerPathRecorder playerPathRecorder;
    public RectTransform pathParent; // UI parent object to hold path UI elements
    public GameObject pathPointPrefab; // Prefab for a UI element representing a path point
    public RectTransform mapImage; // Reference to the UI image to draw upon

    private List<GameObject> uiPathPoints = new List<GameObject>();

   
    private void Update()
    {
        // Sync UI path points count with recorded path points
        while (uiPathPoints.Count < playerPathRecorder.path.Count)
        {
            GameObject newPathPoint = Instantiate(pathPointPrefab, pathParent);
            uiPathPoints.Add(newPathPoint);
        }

        // Update positions of UI path points
        for (int i = 0; i < playerPathRecorder.path.Count; i++)
        {
            Vector3 worldPos = playerPathRecorder.path[i];
            Vector2 normalizedPos = NormalizeWorldToUIPosition(worldPos);

            // Assume the uiPathPoints are RectTransforms to set anchoredPosition
            RectTransform pointRect = uiPathPoints[i].GetComponent<RectTransform>();
            pointRect.anchoredPosition = normalizedPos;
        }
    }

    private Vector2 NormalizeWorldToUIPosition(Vector3 worldPosition)
    {
        // Obtain the relative position of the point in the world space
        Vector3 relativePos = worldPosition - playerPathRecorder.origin;

        // Transform world coordinates to normalized coordinates (assuming mapImage represents the entire world)
        float normalizedX = (relativePos.x / playerPathRecorder.worldWidth) * mapImage.rect.width;
        float normalizedY = (relativePos.z / playerPathRecorder.worldHeight) * mapImage.rect.height;

        // Consider pivot of the image
        normalizedX += mapImage.rect.width * mapImage.pivot.x;
        normalizedY += mapImage.rect.height * mapImage.pivot.y;

        // Get the canvas size
        RectTransform canvasRect = mapImage.root as RectTransform;
        if (canvasRect != null)
        {
            // Convert to top-right origin screen space
            normalizedX = canvasRect.rect.width - normalizedX;
            normalizedY = canvasRect.rect.height - normalizedY;
        }
        else
        {
            Debug.LogError("MapImage is not placed within a Canvas.");
        }

        return new Vector2(normalizedX, normalizedY);
    }




}
