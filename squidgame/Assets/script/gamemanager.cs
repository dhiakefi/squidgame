using UnityEngine;

public class GameManager : MonoBehaviour
{
    public rotatehead dollHeadRotation; // Reference to DollHeadRotation script
    public trackingplayer tracker; // Reference to movement detection script
    public float greenLightDuration = 5f; // Duration for Green Light
    public float redLightDuration = 5f;   // Duration for Red Light

    

    void Start()
    {
        // Start with red Light
        StartRedLight();
    }

    void StartGreenLight()
    {
        dollHeadRotation.SwitchToGreenLight();  // Turn doll's head away
        tracker.isRedLight = true;  // enable movement tracking
        
        Invoke("StartRedLight", greenLightDuration);  // After Green Light duration, switch to Red
    }

    void StartRedLight()
    {
        dollHeadRotation.SwitchToRedLight();  // Turn doll's head towards players
        tracker.isRedLight = false;  // disable movement tracking
        
        Invoke("StartGreenLight", redLightDuration);  // After Red Light duration, switch to Green
    }
}
