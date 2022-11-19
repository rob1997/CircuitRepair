using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AudioManager : Singleton<AudioManager>
{
    public AudioClip clickSound;
    
    public AudioClip clickSound2;
    
    public AudioClip slideSound;
    
    public AudioClip slottedSound;
    
    public AudioClip slottedSound2;
    
    public AudioClip unSlottedSound;
    
    public AudioClip unSlottedSound2;
    
    public AudioClip loseSound;
    
    public AudioClip winSound;
    
    public AudioClip deniedSound;

    protected override void Awake()
    {
        base.Awake();
        
        DontDestroyOnLoad(gameObject);
    }
}
