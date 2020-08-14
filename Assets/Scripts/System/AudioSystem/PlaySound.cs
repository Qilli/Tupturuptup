using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{
    public BaseAudioPlayer audioPlayer;
    private AudioSource source;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public virtual void playSound()
    {
        audioPlayer.play(source);
    }

    public virtual void stopSound()
    {
        audioPlayer.stop(source);
    }

    public virtual void pauseSound()
    {
        audioPlayer.pause(source);
    }

}
