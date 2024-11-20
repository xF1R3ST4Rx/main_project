using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;  // Reference to the AudioSource component
    [SerializeField] private AudioClip soundClip;     // The .wav file to play

    void Start()
    { 
        if (audioSource != null)
        {
            audioSource.clip = soundClip;
        }
    }

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); 
        }
    }
}