using UnityEngine;

public class rotatehead : MonoBehaviour
{
    public Transform headTransform;
    public float rotationSpeed = 5f;
    public Vector3 greenLightRotation = new Vector3(0, 180, 0); // Facing away
    public Vector3 redLightRotation = new Vector3(0, 0, 0); // Facing players

    private bool isTurning = false;
    private Quaternion targetRotation;

    void Start()
    {
        // Start facing away from the players
        targetRotation = Quaternion.Euler(greenLightRotation);
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
      //  Debug.Log("Doll Turning to Face Players.");
        targetRotation = Quaternion.Euler(redLightRotation);
        isTurning = true;
    }

    public void SwitchToGreenLight()
    {
      //  Debug.Log("Doll Turning Away.");
        targetRotation = Quaternion.Euler(greenLightRotation);
        isTurning = true;
    }
}
