using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("---Audio Source---")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource backgroundSound;
    [SerializeField] private AudioSource hitbttnSound;

    [Header("---Audio Source---")]
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] private AudioClip bgSound;
    [SerializeField] private AudioClip hitbttnSoundAudio;

    public static SoundManager soundManager;
    private void Awake()
    {
        if (soundManager == null) 
        {
            soundManager = this;
        }
    }
    private void Start()
    {
            backgroundSound.clip = bgSound;
            backgroundSound.loop = true;
            backgroundSound.Play();
    }
    public void PlaySound()
    {
        audioSource.clip = audioClips[Random.Range(0, 2)];
        audioSource.Play();
    }
    public void hit()
    {
        hitbttnSound.clip = hitbttnSoundAudio;
        hitbttnSound.Play();
    }
}
