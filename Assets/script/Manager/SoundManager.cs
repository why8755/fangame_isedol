using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioSourceType { BGM,Effect,SoundEnd }

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    private Dictionary<string, AudioClip> audioDictionary = new Dictionary<string, AudioClip>();

    public void Play(AudioSourceType source)
    {
        audioSources[(int)source].Play();
    }

    public void PlayOneShot(AudioSourceType source,string name)
    {
        audioSources[(int)source].PlayOneShot(audioDictionary[name]);

    }

    public void Pause(AudioSourceType source)
    {
        audioSources[(int)source].Pause();

    }

    public void Stop(AudioSourceType source)
    {
        audioSources[(int)source].Stop();

    }

    public void Clear()
    {
        foreach(AudioSource audioSource in audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
    }


}
