using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR;

public class rotatehead : MonoBehaviour
{


    public Transform headTransform; 
    public float rotationSpeed = 5f; 
    public Vector3 greenLightRotation = new Vector3(0, 180, 0); // Facing away
    public Vector3 redLightRotation = new Vector3(0, 0, 0); // Facing players

    private bool isTurning = false;
    private Quaternion targetRotation;

    public bool isFacingPlayer = false; // To indicate if the doll is looking at the player

    void Start()
    {
        targetRotation = Quaternion.Euler(greenLightRotation); // Start facing away
        headTransform.rotation = targetRotation;
    }

    void Update()
    {
        if (isTurning)
        {
            headTransform.rotation = Quaternion.Slerp(headTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    public void SwitchToRedLight()
    {
        targetRotation = Quaternion.Euler(redLightRotation);
        isTurning = true;
        isFacingPlayer = true;  
    }

    public void SwitchToGreenLight()
    {
        targetRotation = Quaternion.Euler(greenLightRotation);
        isTurning = true;
        isFacingPlayer = false; 
    }
}
