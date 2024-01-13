using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private AudioSource Radio_Ob;
    public AudioClip[] music;

    public bool trig;

    public Sprite RadioOn;
    public Sprite RadioOff;
    void Start()
    {
        Radio_Ob = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (For_Button.isClick && trig == true)
        {
            if (Radio_Ob.isPlaying)
            {
                Radio_Ob.Stop();
                gameObject.GetComponent<SpriteRenderer>().sprite = RadioOff;
            }
            else
            {
                Radio_Ob.PlayOneShot(music[Random.Range(0, music.Length)]);
                gameObject.GetComponent<SpriteRenderer>().sprite = RadioOn;
            }
            For_Button.isClick = false;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Body"))
        {
            trig = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Body"))
        {
            trig = false;
        }
        For_Button.isClick = false;
    }
}
