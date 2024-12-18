using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] musicsound ;
   // public SFX[] sfxsound;
    public AudioSource musicsource,sfxsource;
    public static AudioManager instance;

    

    private void Awake()
    {
        instance = this;
    }

    public void PlayMusic(string name)
    {
        Sounds sounds = Array.Find(musicsound, sounds => sounds.musicName == name);

        if (sounds == null) 
        {

            print("sounds not found");
        }
        else
        {
            musicsource.clip = sounds.musicClip;
            musicsource.Play();
            
        }
    }
    //public void PlaySfx(string name)
    //{
     
    //    print(name);
    //    SFX sfx = Array.Find(sfxsound, sfx => sfx.sfxName == name);

    //    if (sfx == null)
    //    {
    //        print("sounds not found ");
    //    }
    //    else
    //    {
           
    //        sfxsource.clip = sfx.sfxClip;
    //        sfxsource.Play();
    //    }

    //}
}
