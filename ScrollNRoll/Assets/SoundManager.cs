using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // This tells C# to use Unity's Random by default

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    // Ui
    public AudioClip clickClip;

    // World
    public AudioClip sirenClip;
    public AudioClip raceTimerClip;

    // Chair    
    public AudioClip accelerateClip;
    public AudioClip slowDownClip;
    
    // Gun    
    public AudioClip shootClip;
    public AudioClip reloadClip;
    public AudioClip noAmmoClip;    
        
    // BrainRot    
    public AudioClip brainRotClip;
    
    // Enemy
    public AudioClip dieClip1;
    public AudioClip dieClip2;
    public AudioClip hitClip1;
    public AudioClip hitClip2;
    public AudioClip hitClip3;
    public AudioClip laserClip1;
    public AudioClip laserClip2;
    public AudioClip laserClip3;
    public AudioClip laserClip4;
    
    public static SoundManager Instance { get; private set; }

    private List<AudioClip> dieClips = new List<AudioClip>();
    private List<AudioClip> hitClips = new List<AudioClip>();
    private List<AudioClip> laserClips = new List<AudioClip>();

    private void Awake()
    {
        Instance = this;
        hitClips.Add(hitClip1);
        hitClips.Add(hitClip2);
        hitClips.Add(hitClip3);
        dieClips.Add(dieClip1);
        dieClips.Add(dieClip2);
        laserClips.Add(laserClip1);
        laserClips.Add(laserClip2);
        laserClips.Add(laserClip3);
        laserClips.Add(laserClip4);
    }


    // Ui
    public void PlayClickSound() => audioSource.PlayOneShot(clickClip);

    // World
    public void PlaySirenSound() => audioSource.PlayOneShot(clickClip);

    // Gun
    public void PlayShootSound() => audioSource.PlayOneShot(shootClip);
    public void PlayReloadSound() => audioSource.PlayOneShot(reloadClip);
    public void PlayNoAmmoSound() => audioSource.PlayOneShot(noAmmoClip);
    
    // BrainRot
    public void PlayBrainRotSound() => audioSource.PlayOneShot(brainRotClip);

    // Enemy
    public void PlayDieSound()
    {
        int randomIndex = Random.Range(0, dieClips.Count);
        audioSource.PlayOneShot(dieClips[randomIndex]);
    }
    public void PlayHitSound()
    {
        int randomIndex = Random.Range(0, hitClips.Count);
        audioSource.PlayOneShot(hitClips[randomIndex]);
    }
    public void PlayLaserSound()
    {
        int randomIndex = Random.Range(0, laserClips.Count);
        audioSource.PlayOneShot(laserClips[randomIndex]);
    }

}
