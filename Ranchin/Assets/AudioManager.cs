using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager current;
    public AudioClip crunch;
    public AudioClip pickup;
    public AudioClip sell;
    public AudioSource audioSource;
    public float volume=0.5f;
    void Awake(){
        current = this;
    }
    public void playCrunch(){
        audioSource.PlayOneShot(crunch, volume);
    }
    
    public void playPickup(){
        audioSource.PlayOneShot(pickup, volume);
    }

    public void playSell(){
        audioSource.PlayOneShot(sell, volume);
    }
}