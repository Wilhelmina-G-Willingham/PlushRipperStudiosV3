using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    //game managers use Singleton pattern, as only one of each is ever needed.
    public static SoundFXManager instance;

    //store a reference to the object that will play sound effects.
    [SerializeField]
    private AudioSource soundFXPlayer;
    //store a reference to the object that will play music
    [SerializeField]
    private AudioSource SoundMusicPlayer;

    [SerializeField]
    private AudioClip sceneMusicClip;

    public bool repeatingsoundplaying = false;

    //ensure that this is the only instance 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        //spawn the music player once it has been ensured that there is only one instance of this class
        PlayMusicClip();
    }

    public void PlaySoundFXClip(AudioClip clip, Transform soundlocation, float volume)
    {
        //spawn in gameobject at the location the sounds needs to be played
        AudioSource audiosource = Instantiate(soundFXPlayer, soundlocation.position, Quaternion.identity);

        //assign audioclip
        audiosource.clip = clip;
        
        //assign volume
        audiosource.volume = volume;
        
        //play sound
        audiosource.Play();
        //get length
        float cliplength = audiosource.clip.length;
        
        //destroy object after playing clip
        Destroy(audiosource.gameObject, cliplength);
    }


    //used to spawn the music player in the scene. Expected to only be called by this class, 
    private void PlayMusicClip()
    {
        AudioSource audiosource = Instantiate(SoundMusicPlayer, new Vector3 (0,0,0), Quaternion.identity);
        
        audiosource.clip = sceneMusicClip;
        
        audiosource.Play();

        audiosource.loop = true;
    }
        
}
