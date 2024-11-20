using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; 
    [SerializeField] private AudioClip soundClip;     

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