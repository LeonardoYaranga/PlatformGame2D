using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Debug.Log("More than one instance of AudioManager!");
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproduceSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
