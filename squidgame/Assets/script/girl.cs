using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class girl : MonoBehaviour
{
    [SerializeField] AudioSource girlsingsource;

    [SerializeField] AudioSource girlrotateource;
 
    [SerializeField] AudioClip girlsing;

    [SerializeField] AudioClip girlrotate;

    [SerializeField] float totaltime=70f;

    [SerializeField] float breaktime = 4f;//break for 4seconds

    readonly float initialsoundduration = 5f; //the duration of song (editable)
    readonly float finalsoundduration = 2.5f; //the duration of song*2 (editable)

    float elapsedtime = 0f;

    bool playing=false;

    Coroutine headrotationcoroutine=null;

    PlayerPrefs player;

    Transform head;

    bool scan = false;


void Awake()
{
if(girlsingsource==null || girlsing==null || girlrotateource==null || girlrotate == null)
        {
            Debug.Log("one of the files is not assigned");
        }
        girlsingsource.clip = girlsing;
        girlsingsource.loop = false;

        girlrotateource.clip = girlsing;
        girlrotateource.loop = false;

        head = transform.Find("Dollhead");

     // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
    void Update()
    {
        if (elapsedtime<totaltime)
        {
            elapsedtime += Time.deltaTime;
            
            if (!playing)
            {
              float currentsoundduration = Mathf.Lerp(initialsoundduration, finalsoundduration, elapsedtime / totaltime);
              girlsingsource.pitch = initialsoundduration / currentsoundduration;
              girlsingsource.Play();
              playing = true;

             // Invoke(nameof(), currentsoundduration);
             }
        }

        if (elapsedtime >= totaltime)
        {
         /* if (!player.Playerdead())
            {
                player.Killplayer();
            }
            return;*/
        }
        if (scan)
        {
           /* if (player.move)
            {
                player.killplayer();
            }*/
        }
    }
    void stopsing()
    {
        girlsingsource.Stop();

        Invoke(nameof(ResumePlayback), breaktime);
        rotatehead();
    }
    void ResumePlayback()
    {
        playing = false;
        scan = false;
        rotatehead(true);
    }
    void rotatehead(bool rotate=false)
    {
        if(headrotationcoroutine != null)
        {
            StopCoroutine(headrotationcoroutine);
        }
        girlrotateource.Play();
        headrotationcoroutine = StartCoroutine(RotatHeadOverTime(0.2f,rotate));
    }
    IEnumerator RotatHeadOverTime(float seconds , bool rotate = false)
    {
        float elapsedTime = 0;
        Quaternion StartRotation = head.rotation;
        Quaternion endRotation = Quaternion.Euler(0, rotate ? 0 : 180, 0);

        while (elapsedtime < seconds)
        {
            head.rotation = Quaternion.Slerp(StartRotation, endRotation, elapsedTime / seconds);
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        scan = !rotate;
    }
}
