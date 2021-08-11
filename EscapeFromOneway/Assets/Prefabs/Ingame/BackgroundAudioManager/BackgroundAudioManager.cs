using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioManager : MonoBehaviour
{
    public List<AudioClip> audioClips;
    AudioClip audioClip;
    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (gameObject.name == "Wind") WindSoundInit();
    }

    void Update()
    {
        if (gameObject.name == "Wind") WindSoundHandler();
    }

    void WindSoundInit()
    {
        int index = UnityEngine.Random.Range(0, audioClips.Count - 1);
        audioClip = audioClips[index];
        audioSource.clip = audioClip;
        audioSource.volume = AudioSourceConfig.DefaultWindSound;
        audioSource.loop = true;
        audioSource.Play();
    }
    void WindSoundHandler()
    {
        audioSource.volume = Math.Abs(audioSource.volume + UnityEngine.Random.Range(
            AudioSourceConfig.DeltaWindSoundRange * -1,
            AudioSourceConfig.DeltaWindSoundRange
        ));
        if (audioSource.volume > AudioSourceConfig.MaxWindSound) audioSource.volume = AudioSourceConfig.MaxWindSound;
    }
}
