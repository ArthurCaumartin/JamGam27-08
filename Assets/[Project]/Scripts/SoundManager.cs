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
    private bool _timeDialogue;
    private float _dialoguedelay;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(_timeDialogue)
        {
            _dialoguedelay += Time.deltaTime;
            if(_dialoguedelay > .5f)
            {
                _dialoguedelay = 0;
                _timeDialogue = false;
                PlayOnShot(_playerDlialogue[Random.Range(0, _playerDlialogue.Count)]);
            }
        }
    }

    public void PlayOnShot(AudioClip clip, bool playDialogueAfter = false)
    {
        _source.PlayOneShot(clip);
        if(playDialogueAfter) _timeDialogue = true;
    }
}
