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

    public void SetClip(string shortDisplayName)
    {
        AudioClip clip = clips.FirstOrDefault(c => c.name == shortDisplayName);
        
        if(clip!= null)
        {
            audioSource.clip = clip;
            audioSource.loop = true;
        }
        else
        {
            Debug.LogError($"没有找到名为 {shortDisplayName} 的 AudioClip。");
        }
    }

    public void Play()
    {
        audioSource.Play();
    }

    public void TearDown()
    {
        GameObject.Destroy(gameObject);
    }
}
