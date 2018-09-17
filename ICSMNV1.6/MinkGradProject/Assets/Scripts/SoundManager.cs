using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundExplosion;
    AudioSource MyAudio;

    public static SoundManager instance;

    void Awake()
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;


    }
    // Use this for initialization
    void Start()
    {
        MyAudio = GetComponent<AudioSource>();

    }
    public void Playsound(AudioClip clip)
    {
        MyAudio.PlayOneShot(clip); 

    }
    // Update is called once per frame
    void Update()
    {

    }
}
