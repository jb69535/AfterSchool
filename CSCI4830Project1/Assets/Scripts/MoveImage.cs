using UnityEngine;
using UnityEngine.UI;

public class MoveImage : MonoBehaviour
{
    public RectTransform imageRectTransform; // UI image to move
    public Transform playerTransform; // Player transform
    public Transform referenceTransform; // Reference GameObject transform
    public float scaleFactor = 100f; // A scale factor to map world units to UI units

    private void Update()
    {
        // Calculate the relative position of the player to the reference object
        Vector3 relativePosition = playerTransform.position - referenceTransform.position;

        // Create a 2D movement vector for UI, scaling as desired
        Vector2 uiMove = new Vector2(relativePosition.x, relativePosition.z) * scaleFactor;


        uiMove.x = relativePosition.x * scaleFactor + 710;
        uiMove.y = relativePosition.z * scaleFactor - 645;
        // Update the image position
        imageRectTransform.anchoredPosition = uiMove;
    }
}
