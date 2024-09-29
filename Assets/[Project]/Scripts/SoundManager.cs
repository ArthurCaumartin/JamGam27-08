using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource _source;
    [Space]
    public AudioClip _damageclip;
    public List<AudioClip> _playerDlialogue = new List<AudioClip>();
    [Space]
    public AudioClip _repulsion;
    public AudioClip _ballHit;

    void Awake()
    {
        instance = this;
    }

    public void PlayOnShot(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }
}
