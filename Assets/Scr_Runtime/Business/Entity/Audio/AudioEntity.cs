using System;
using UnityEngine;
using HNY;
using System.Linq;

public class AudioEntity : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public IDSignature idSig;

    public AudioClip[] clips;

    public void Ctor()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetClip(int noteNumber)
    {
        if(audioSource == null)
        {
            Debug.LogError("AudioSource is null");
            return;
        }
        
        audioSource.clip = clips[noteNumber - 48];
        audioSource.loop = false;
    }

    public void Play()
    {
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void TearDown()
    {
        GameObject.Destroy(gameObject);
    }
}
