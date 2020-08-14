using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[CreateAssetMenu(menuName = "EngineAssets/System/Audio/AudioObject")]

public class AudioObject : ScriptableObject
{
    public SoundObjectSettings settings;
    public AudioClip clip;
    public void setSettings(AudioSource audioSource)
    {
        if(settings == null)
        {
            return;
        }
        settings.setSettings(audioSource);
    }

    public bool tryPlaySound(AudioSource source)
    {
       // GlobalDataContainer.It.audioController.removeAudioSource(source);
        source.Stop();
        if(source == null)
        {
            return false;
        }
        
        setSettings(source);
        source.clip = clip;


        if (source.clip != null)
        {
            //GlobalDataContainer.It.audioController.addAudioSourceToPlayed(source);
            source.Play();
            return true;
        }
        return false;
    }


    public void playClipAtPoint(AudioSource source)
    {
        source.Stop();
        source.PlayOneShot(clip);
    }


    public void stopClip(AudioSource source)
    {
        //GlobalDataContainer.It.audioController.removeAudioSource(source);
        source.Stop();
    }

}
