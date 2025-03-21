using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackingplayer : MonoBehaviour
{
    public Transform headTransform; //  the VR Camera (HMD)
    public Transform leftHandTransform; //  the Left Hand Controller
    public Transform rightHandTransform; // the Right Hand Controller

    private Vector3 lastHeadPosition;
    private Vector3 lastLeftHandPosition;
    private Vector3 lastRightHandPosition;

    public bool isRedLight = false; // Change this when switching to "Red Light"
   // public bool isFacingPlayer = false; // Whether the doll is facing the player

    void Start()
    {
        lastHeadPosition = headTransform.position;
        lastLeftHandPosition = leftHandTransform.position;
        lastRightHandPosition = rightHandTransform.position;
    }

    void Update()
    {
        // Check if the doll is facing the player during Red Light
        if (isRedLight )
        {
            if (HasMoved(headTransform, ref lastHeadPosition) ||
                HasMoved(leftHandTransform, ref lastLeftHandPosition) ||
                HasMoved(rightHandTransform, ref lastRightHandPosition))
            {
                Debug.Log("Player Moved! Eliminated.");
                // Handle elimination (e.g., game over, restart level)
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

}
