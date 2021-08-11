using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioClip onFallingSound;
    public AudioClip onDieSound;
    public AudioClip onSuccessSound;
    public List<AudioClip> onMoveSound;
    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.loop = false;
    }

    void InitAudioSource(AudioClip AudioClip, float Volume)
    {
        audioSource.clip = AudioClip;
        audioSource.volume = Volume;
    }
    public void PlayOnFallingSound()
    {
        InitAudioSource(onFallingSound, AudioSourceConfig.PlayerOnFallingSoundVolume);
        audioSource.Play();
    }
    public void PlayOnDieSound()
    {
        InitAudioSource(onDieSound, AudioSourceConfig.PlayerOnDieSoundVolume);
        audioSource.Play();
    }
    public void PlayOnSuccessSound()
    {
        InitAudioSource(onSuccessSound, AudioSourceConfig.PlayerOnSuccessVolume);
        audioSource.Play();
    }
    public void PlayOnMoveSound()
    {
        int index = Random.Range(0, onMoveSound.Count - 1);
        InitAudioSource(onMoveSound[index], AudioSourceConfig.PlayerOnMoveSoundVolume);
        audioSource.Play();
    }
}
