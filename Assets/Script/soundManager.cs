using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager Instance;
    private AudioSource audioSource;
    public AudioClip crashSound;
    public AudioClip addSound;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }

    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void playSound(bool whySound)
    {
        if (whySound)
        {
            audioSource.PlayOneShot(addSound);
        }
        else
        {
            audioSource.PlayOneShot(crashSound);
        }

        
    }
}
