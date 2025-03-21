using UnityEngine;

public class trackingplayer : MonoBehaviour
{
    public Transform headTransform; // The VR Camera (HMD)
    public Transform leftHandTransform; // Left Hand Controller
    public Transform rightHandTransform; // Right Hand Controller

    private Vector3 lastHeadPosition;
    private Vector3 lastLeftHandPosition;
    private Vector3 lastRightHandPosition;

    public bool isRedLight = false; // True when tracking player movement

    void Start()
    {
        //Debug.Log("Tracking System Initialized.");
        ResetLastKnownPositions(); // Set initial positions
    }

    void Update()
    {
      //  Debug.Log("Update Running - isRedLight: " + isRedLight);

        if (isRedLight)
        {
          //  Debug.Log("Tracking is ACTIVE.");

            if (HasMoved(headTransform, ref lastHeadPosition) ||
                HasMoved(leftHandTransform, ref lastLeftHandPosition) ||
                HasMoved(rightHandTransform, ref lastRightHandPosition))
            {
                Debug.Log("Player Moved! Eliminated.");
                // Handle player elimination (e.g., Game Over)
            }
        }
    }

    bool HasMoved(Transform target, ref Vector3 lastPosition)
    {
        float movementThreshold = 0.01f; // Adjust sensitivity
        if (Vector3.Distance(target.position, lastPosition) > movementThreshold)
        {
            lastPosition = target.position; // Update position
            return true; // Movement detected
        }
        return false;
    }

    public void ResetLastKnownPositions()
    {
        //Debug.Log("Resetting Player Position for Tracking.");
        lastHeadPosition = headTransform.position;
        lastLeftHandPosition = leftHandTransform.position;
        lastRightHandPosition = rightHandTransform.position;
    }
}
