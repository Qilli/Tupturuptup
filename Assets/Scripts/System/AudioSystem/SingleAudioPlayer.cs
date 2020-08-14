using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "EngineAssets/System/Audio/SingleAudioPlayer")]
public class SingleAudioPlayer : BaseAudioPlayer
{
    public AudioClip clip;
    public bool looped = false;
    public float volume = 1.0f;
    public AudioMixerGroup mixer;

    public override void play(AudioSource source)
    {
        source.clip = clip;
        source.volume = volume;
        source.loop = looped;
        if(mixer != null)
        {
            source.outputAudioMixerGroup = mixer;
        }
        source.Play();
    }

    public override void stop(AudioSource source)
    {
        source.Stop();
    }

    public override void pause(AudioSource source)
    {
        if (source.isPlaying)
            source.Pause();
        else source.Play();
    }

}
