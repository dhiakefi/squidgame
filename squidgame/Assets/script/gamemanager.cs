using UnityEngine;

public class GameManager : MonoBehaviour
{
    public rotatehead dollHeadRotation; // Reference to Doll Head Rotation script
    public trackingplayer tracker; // Reference to movement detection script
    public float greenLightDuration = 5f; // Green Light duration
    public float redLightDuration = 5f;   // Red Light duration

    public AudioSource dollAudio;
    public AudioClip redLightSong;
    public AudioSource rotatehead;
    public AudioClip rotate;

    void Start()
    {
        // Start with Green Light (Doll facing away)
        StartGreenLight();
    }

    void StartGreenLight()
    {
       // Debug.Log("Green Light! Players can move.");

        dollHeadRotation.SwitchToGreenLight();  // Turn doll's head away
        tracker.isRedLight = false;  // Disable movement tracking

        Invoke("PlaySongThenTurn", greenLightDuration);  // Wait, then play song
    }

    void StartRedLight()
    {
      //  Debug.Log("Red Light! Tracking players now.");

        dollHeadRotation.SwitchToRedLight();  // Turn doll's head towards players
        tracker.ResetLastKnownPositions(); // Reset tracking positions before tracking starts
        tracker.isRedLight = true;  // Enable movement tracking
        rotatehead.clip = rotate;
        rotatehead.Play();

        Invoke("StartGreenLight", redLightDuration);  // Switch back to Green Light
    }

    void PlaySongThenTurn()
    {
        if (dollAudio && redLightSong)
        {
            dollAudio.clip = redLightSong;
            dollAudio.Play();
           
            //Debug.Log("Playing Song...");

            Invoke("StartRedLight", redLightSong.length);  // Wait for song to finish, then track players
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is missing!");
        }
    }
}
