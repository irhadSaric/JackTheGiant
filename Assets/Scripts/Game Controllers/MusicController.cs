using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    private AudioSource audioSoruce;
    
    void Awake()
    {
        MakeSingleton();
        audioSoruce = GetComponent<AudioSource>();
    }

    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusic(bool play)
    {
        if (play)
        {
            if (!audioSoruce.isPlaying)
            {
                audioSoruce.Play();
            }
        }
        else
        {
            if (audioSoruce.isPlaying)
            {
                audioSoruce.Stop();
            }
        }
    }
}
